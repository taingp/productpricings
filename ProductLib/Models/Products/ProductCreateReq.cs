namespace ProductLib;
public class ProductCreateReq
    : ProductBase
    , ICreateReq
{
    public string Code { get; set; } = default!;
    public string? Category { get; set; } = default;
    public List<PricingReqFC>? Pricings { get; set; } = default;
}
