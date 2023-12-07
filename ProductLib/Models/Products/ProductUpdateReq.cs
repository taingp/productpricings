namespace ProductLib;

public class ProductUpdateReq
    : ProductBase
    , IUpdateReq
{
    public string Key { get; set; } = default!;
    public string? Category { get; set; } = default;
    public PricingFU? PricingFU { get; set; } = default!;
}