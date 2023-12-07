using Microsoft.EntityFrameworkCore;
using ProductLib.Extensions;
using System;

namespace ProductLib;
public class ProductService
    :IProductService
{
    private readonly IProductRepo _repo = default!;
    private DateTime? _actingDate = DateTime.Now;
    
    public ProductService(IProductRepo repo) { _repo = repo; }

    public IProductService SetActingDate(DateTime? actingDate) 
    { 
        _actingDate = actingDate; 
        return this; 
    }

    public bool Exist(string key)
    {
        return _repo.GetQueryable().Any(x => x.Id == key || x.Code.ToLower() == key.ToLower());
    }

 
    public Result<string?> Create(ProductCreateReq req)
    {
        string text = "Creating Product";
        if (Exist(req.Code) == true)
            return Result<string?>.Fail($"{text}: the code, {req.Code}, does already exist");
        
        Product entity = req.ToEntity();
        try
        {
            _repo.Create(entity);
            return Result<string?>.Success(entity.Id, $"{text}: Succeded");
        }
        catch (Exception ex)
        {
            return Result<string?>.Fail($"{text}: Failed>{ex.Message}");
        }
    }
    public Result<int> CreateRange(IEnumerable<ProductCreateReq> reqs)
    {
        string text = "Creating products";
        var codes = reqs.Select(x => x.Code.Trim()).Distinct().ToList();
        if (codes?.Count() != reqs?.Count())
        {
            return Result<int>.Fail($"{text}: failed > there are some duplicate codes");
        }
        var entities = reqs?.Select(x => x.ToEntity()).ToList() ?? new();
        try
        {
            int effecteds = _repo.CreateRange(entities);
            return Result<int>.Success(effecteds, $"{text}: {effecteds} succeded");
        }
        catch (Exception ex)
        {
            return Result<int>.Fail($"{text}: failed > {ex.Message}");
        }
    }

    public Result<List<ProductResponse>> ReadAll()
    {
        var text = "Getting products";
        var actingDate = _actingDate ?? DateTime.Now;
        var result = _repo.GetQueryable()
                          .Include(x => x.Pricings!.Where(p => p.EffectedFrom <= actingDate))
                          .Select(x => x.ToResponse())
                          .ToList();
        return Result<List<ProductResponse>>.Success(result, $"{text}: {result.Count} found");
    }
    public Result<ProductResponse?> Read(string key)
    {
        var text = "Getting product";
        var actingDate = _actingDate ?? DateTime.Now;
        var entity = _repo.GetQueryable()
                          .Include(x => x.Pricings!.Where(p => p.EffectedFrom <= actingDate))
                          .FirstOrDefault(x => x.Id == key || x.Code.ToLower() == key.ToLower());
        return Result<ProductResponse?>.Success(entity?.ToResponse(), 
                                                $"{text}:{(entity != null ? "found" : "not found")} a product with id/code, {key}");
    }

    public Result<ProductPricingResponse?> ReadPricings(string key)
    {
        var text = "Getting product";
        var actingDate = _actingDate ?? DateTime.Now;
        var entity = _repo.GetQueryable()
                          .Include(x => x.Pricings)
                          .FirstOrDefault(x => x.Id == key || x.Code.ToLower() == key.ToLower());
        return Result<ProductPricingResponse?>.Success(entity?.ToPricingsResponse(), $"{text}:{(entity != null ? "found" : "not found")}");
    }
    public Result<string?> Update(ProductUpdateReq req)
    {
        var text = "Updating product";
        var entity = _repo.GetQueryable()
                          .Include(x=>x.Pricings)
                          .FirstOrDefault(x => (x.Id == req.Key)
                                            || (x.Code.ToLower() == req.Key.ToLower()));
        if (entity == null)
            return Result<string?>.Fail($"{text}: no id/code, {req.Key}");

        entity.Copy(req);
        entity.Pricings ??= new();

        if (req.PricingFU != null)
        {
            //check and delete found pricings
            if ((entity.Pricings.Count > 0) && (req.PricingFU?.Deleteds?.Any() ?? false))
            {
                var deletePricings = entity.Pricings.Where(p => req.PricingFU.Deleteds.Contains(p.Id)).ToList() ?? new();
                deletePricings.ForEach(x => { _repo.DbContext.Entry(x).State = EntityState.Deleted; });
            }

            //checking and updating found pricings
            if ((entity.Pricings.Count > 0) && (req.PricingFU?.Updateds?.Any() ?? false))
            {
                var updateIds = req.PricingFU.Updateds.Select(x => x.Id).ToList() ?? new();
                var foundPricings = entity.Pricings.Where(x => updateIds.Contains(x.Id)).ToList() ?? new();
                foundPricings?.ForEach(x =>
                {
                    var reqPricing = req.PricingFU.Updateds.FirstOrDefault(p => p.Id == x.Id);
                    if (reqPricing != null)
                    {
                        x.Value = reqPricing.Value;
                        x.LastUpdatedOn = DateTime.Now;
                        _repo.DbContext.Entry(x).State = EntityState.Modified;
                    }
                });
            }
            //checking and creting new pricings
            if (req.PricingFU?.Createds?.Any() ?? false)
            {
                req.PricingFU.Createds.ForEach(x =>
                {
                    var pricingEntity = new Pricing()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ProductId = entity.Id,
                        Value = x.Value,
                        EffectedFrom = x.EffectedFrom ?? DateTime.Now,
                        CreatedOn = DateTime.Now,
                        LastUpdatedOn = null,
                        Product = entity
                    };
                    _repo.DbContext.Entry(pricingEntity).State = EntityState.Added;
                });
            }
        }

        try
        {
            var result = _repo.Update(entity);
            return result == true ? 
                      Result<string?>.Success(entity.Id, $"{text}: succeded")
                    : Result<string?>.Fail($"{text}: failed for the id/code, {req.Key}");
        }
        catch (Exception ex)
        {
            return Result<string?>.Fail($"{text}: failed > {ex.Message}");
        }
    }

    public Result<string?> Delete(string key)
    {
        var text = "Deleting product";
        var entity = _repo.GetQueryable()
            .Include(x=>x.Pricings)
            .FirstOrDefault(x => (x.Id == key) || (x.Code.ToLower() == key.ToLower()));
        if (entity == null)
            return Result<string?>.Fail($"{text}: no id/code, {key}");

        if (entity.Pricings?.Any() ?? false)
            return Result<string?>.Fail($"{text}: the product id/code, {key}, has prices");

        try
        {
            var result = _repo.Delete(entity);
            return result == true ? 
                      Result<string?>.Success(entity.Id, $"{text}: succeded")
                    : Result<string?>.Fail($"{text}: failed for the id/code, {key}");
        }
        catch (Exception ex)
        {
            return Result<string?>.Fail($"{text}: failed > {ex.Message}");
        }
    }

    public Result<int> ForceDelete(string key)
    {
        var text = "Deleting product";
        var found = _repo.GetQueryable()
            .Include(x => x.Pricings)
            .FirstOrDefault(x => (x.Id == key) || (x.Code.ToLower() == key.ToLower()));
        if (found == null)
            return Result<int>.Fail($"{text}: no id/code, {key}");
        try
        {
            if (found.Pricings?.Any() ?? false)
            {
                _repo.DbContext.Set<Pricing>().RemoveRange(found.Pricings);
            }
            _repo.DbContext.Set<Product>().Remove(found);
            int n = _repo.DbContext.SaveChanges();
            return n > 0 ? Result<int>.Success(n, $"{text}: succeded")
                         : Result<int>.Fail($"{text}: failed for the id/code, {key}");
        }
        catch (Exception ex)
        {
            return Result<int>.Fail(ex.Message);
        }
    }

}
