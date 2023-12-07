namespace ProductLib;

public interface IProductService 
    : IService<ProductResponse, ProductCreateReq, ProductUpdateReq> 
{
    IProductService SetActingDate(DateTime? actingDate);
    Result<ProductPricingResponse?> ReadPricings(string key);
    Result<int> ForceDelete(string key);
}
