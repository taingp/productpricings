namespace ProductLib;

public class ProductPricingResponse
    : ProductBase
    , IResponse
{
    public string? Id { get; set; } = default;
    public string Code { get; set; } = default!;
    public string? Category { get; set; } = default;
    public List<PricingResponse>? Pricings { get; set; } = default;
}