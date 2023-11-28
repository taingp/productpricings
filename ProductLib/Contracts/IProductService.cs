namespace ProductLib;

public interface IProductService 
    : IService<ProductResponse, ProductCreateReq, ProductUpdateReq> 
{
    IProductService SetActingDate(DateTime? actingDate);
}
