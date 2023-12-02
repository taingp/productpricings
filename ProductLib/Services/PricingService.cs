using Microsoft.EntityFrameworkCore;
using ProductLib.Extensions;

namespace ProductLib;

public class PricingService
    : IPricingService
{
    private readonly IPricingRepo _repo = default!;
    private readonly IProductRepo _productRepo;

    public PricingService(IPricingRepo repo, IProductRepo productRepo) 
    { 
        _repo = repo;
        _productRepo = productRepo;
    }

    public bool Exist(string key)
    {
        return _repo.GetQueryable().Any(x => x.Id == key );
    }
 
    public Result<string?> Create(PricingCreateReq req)
    {
        var text = "Creating pricing";
        var foundProduct = _productRepo.GetQueryable()
                                       .FirstOrDefault(x => x.Id == req.ProductKey 
                                                         || x.Code.ToLower() == req.ProductKey.ToLower());
        if (foundProduct == null)
        {
            return Result<string?>.Fail($"{text}: no product with id/code, {req.ProductKey}");
        }
        req.ProductKey = foundProduct.Id;
        Pricing entity = req.ToEntity();
        try
        {
            _repo.Create(entity);
            return Result<string?>.Success(entity.Id, $"{text}: succeded");
        }
        catch (Exception ex)
        {
            return Result<string?>.Fail($"{text}: failed> {ex.Message}");
        }
    }
    public Result<int> CreateRange(IEnumerable<PricingCreateReq> reqs)
    {
        var text = "Creating pricings";
        return Result<int>.Fail($"{text}: Not implemented");
    }

    public Result<List<PricingResponse>> ReadAll()
    {
        var text = "Getting pricings";
        var actingDate = DateTime.Now;
        var result = _repo.GetQueryable()
                          .Include(x => x.Product)
                          .Select(x => x.ToResponse())
                          .ToList();
        return Result<List<PricingResponse>>.Success(result, $"{text}: {result.Count} found");
    }
    public Result<PricingResponse?> Read(string key)
    {
        var text = "Getting pricing";
        var actingDate = DateTime.Now;
        var entity = _repo.GetQueryable()
                          .Include(x => x.Product)
                          .FirstOrDefault(x => x.Id == key);
        return Result<PricingResponse?>.Success(entity?.ToResponse(), 
                                               $"{text}:{(entity != null ? "found" : "not found")} the pricing with id, {key}");
    }

    public Result<string?> Update(PricingUpdateReq req)
    {
        var text = "Updating pricing";
        var entity = _repo.GetQueryable()
                          .AsNoTracking()
                          .FirstOrDefault(x => x.Id == req.Id);
        if (entity == null)
            return Result<string?>.Fail($"{text}: no id, {req.Id}");

        var foundProduct = _productRepo.GetQueryable()
                               .FirstOrDefault(x => x.Id == req.ProductKey || x.Code.ToLower() == req.ProductKey.ToLower());
        if (foundProduct == null)
        {
            return Result<string?>.Fail($"{text}: no product id/code, {req.ProductKey}");
        }
        req.ProductKey = foundProduct.Id;

        entity.Copy(req);
        try
        {
            var result = _repo.Update(entity);
            return result == true ? 
                      Result<string?>.Success(entity.Id, $"{text}: succeded")
                    : Result<string?>.Fail($"{text}: failed for the id, {req.Id}");
        }
        catch (Exception ex)
        {
            return Result<string?>.Fail($"{text}: failed > {ex.Message}");
        }
    }
    
    public Result<string?> Delete(string key)
    {
        var text = "Deleting pricing";
        var entity = _repo.GetQueryable().FirstOrDefault(x => x.Id == key);
        if (entity == null)
            return Result<string?>.Fail($"{text}: no id, {key}");
        try
        {
            var result = _repo.Delete(entity);
            return result == true ? 
                      Result<string?>.Success(entity.Id, $"{text}: succeded")
                    : Result<string?>.Fail($"{text}: failed for id, {key}");
        }
        catch (Exception ex)
        {
            return Result<string?>.Fail($"{text}: failed > {ex.Message}");
        }
    }
}
