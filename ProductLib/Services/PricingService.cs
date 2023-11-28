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
        var foundProduct = _productRepo.GetQueryable().FirstOrDefault(x => x.Id == req.ProductKey || x.Code.ToLower() == req.ProductKey.ToLower());
        if (foundProduct == null)
            return Result<string?>.Fail($"The product with the id/code, {req.ProductKey}, does not exist");

        req.ProductKey = foundProduct.Id;
     
        Pricing entity = req.ToEntity();
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

    public Result<List<PricingResponse>> ReadAll()
    {
        var result = _repo.GetQueryable()
                          .Include(x=>x.Product)
                          .Select(x => x.ToResponse())
                          .ToList();
        return Result<List<PricingResponse>>.Success(result);
    }
    public Result<PricingResponse?> Read(string key)
    {
        var entity = _repo.GetQueryable()
            .Include(x => x.Product)
            .FirstOrDefault(x => x.Id == key );
        return Result<PricingResponse?>.Success(entity?.ToResponse());
    }

    public Result<string?> Update(PricingUpdateReq req)
    {
        var entity = _repo.GetQueryable()
                         .FirstOrDefault(x => x.Id == req.Id);
        if (entity == null)
            return Result<string?>.Fail($"No pricing with id, {req.Id}");

        var foundProduct = _productRepo.GetQueryable().FirstOrDefault(x => x.Id == req.ProductKey || x.Code.ToLower() == req.ProductKey.ToLower());
        if (foundProduct ==null)
            return Result<string?>.Fail($"No product with id/code, {req.ProductKey}");
        
        req.ProductKey = foundProduct.Id;
        entity.Copy(req);
        try
        {
            var result = _repo.Update(entity);
            return result == true ? Result<string?>.Success(entity.Id, "Successfully updated")
                    : Result<string?>.Fail($"Failed to update pricing with id, {req.Id}");
        }
        catch (Exception ex)
        {
            return Result<string?>.Fail(ex.Message);
        }
    }
    public Result<string?> Delete(string key)
    {
        var entity = _repo.GetQueryable()
                         .FirstOrDefault(x => x.Id == key);
        if (entity == null)
            return Result<string?>.Fail($"No pricing with id, {key}");
        try
        {
            var result = _repo.Delete(entity);
            return result == true ?
                      Result<string?>.Success(entity.Id, "Successfully deleted")
                    : Result<string?>.Fail($"Failed to delete pricing with id, {key}");
        }
        catch (Exception ex)
        {
            return Result<string?>.Fail(ex.Message);
        }
    }
}
