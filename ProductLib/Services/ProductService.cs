using Microsoft.EntityFrameworkCore;
using ProductLib.Extensions;

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
 
    public Result<string?> Update(ProductUpdateReq req)
    {
        var text = "Updating product";
        var entity = _repo.GetQueryable().FirstOrDefault(x => (x.Id == req.Key)
                                                          || (x.Code.ToLower() == req.Key.ToLower()));
        if (entity == null)
            return Result<string?>.Fail($"{text}: no id/code, {req.Key}");

        entity.Copy(req);
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
        var entity = _repo.GetQueryable().FirstOrDefault(x => (x.Id == key)
                                                          || (x.Code.ToLower() == key.ToLower()));
        if (entity == null)
            return Result<string?>.Fail($"{text}: no id/code, {key}");
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
}
