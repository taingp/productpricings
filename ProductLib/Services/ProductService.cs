using Microsoft.EntityFrameworkCore;
using ProductLib.Extensions;

namespace ProductLib;
public class ProductService
    :IProductService
{
    private readonly IProductRepo _repo = default!;
    private DateTime? _actingDate = DateTime.Now;
    
    public ProductService(IProductRepo repo) { _repo = repo; }

    public IProductService SetActingDate(DateTime? actingDate) { _actingDate = actingDate; return this; }
    public bool Exist(string key)
    {
        return _repo.GetQueryable().Any(x => x.Id == key || x.Code.ToLower() == key.ToLower());
    }
    public Result<string?> Create(ProductCreateReq req)
    {
        if (Exist(req.Code)== true)
            return Result<string?>.Fail($"The product with the code, {req.Code}, does already exist");
        Product entity = req.ToEntity();
        try
        {
            _repo.Create(entity);
            return Result<string?>.Success(entity.Id, "Successfully created");
        }
        catch (Exception ex)
        {
            return Result<string?>.Fail(ex.Message);
        }
    }

    public Result<List<ProductResponse>> ReadAll()
    {
        var result = _repo.GetQueryable()
                          .Include(x=>x.Pricings!.Where(p=>p.EffectedFrom<= _actingDate))
                          .Select(x => x.ToResponse())
                          .ToList();
        return Result<List<ProductResponse>>.Success(result);
    }
    public Result<ProductResponse?> Read(string key)
    {
        var entity = _repo.GetQueryable()
                          .Include(x => x.Pricings!.Where(p => p.EffectedFrom <= _actingDate))
                          .FirstOrDefault(x => x.Id == key || x.Code.ToLower() == key.ToLower());
        return Result<ProductResponse?>.Success(entity?.ToResponse());
    }

    public Result<string?> Update(ProductUpdateReq req)
    {
        var entity = _repo.GetQueryable()
                         .FirstOrDefault(x => (x.Id == req.Key) || (x.Code.ToLower() == req.Key.ToLower()));
        if (entity == null)
            return Result<string?>.Fail($"No product with id/code, {req.Key}");
        entity.Copy(req);
        try
        {
            var result = _repo.Update(entity);
            return result == true ? Result<string?>.Success(entity.Id, "Successfully updated")
                    : Result<string?>.Fail($"Failed to update product with id/code, {req.Key}");
        }
        catch (Exception ex)
        {
            return Result<string?>.Fail(ex.Message);
        }
    }
    public Result<string?> Delete(string key)
    {
        var entity = _repo.GetQueryable()
                         .FirstOrDefault(x => (x.Id == key) || (x.Code.ToLower() == key.ToLower()));
        if (entity == null)
            return Result<string?>.Fail($"No product with id/code, {key}");
        try
        {
            var result = _repo.Delete(entity);
            return result == true ? 
                      Result<string?>.Success(entity.Id, "Successfully deleted")
                    : Result<string?>.Fail($"Failed to delete product with id/code, {key}");
        }
        catch (Exception ex)
        {
            return Result<string?>.Fail(ex.Message);
        }
    }
}
