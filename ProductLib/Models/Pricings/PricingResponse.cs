namespace ProductLib;

public class PricingResponse
    :PricingBase
    , IResponse
{
    public string? Id { get; set; } = default;
    public string ProductCode { get; set; } = default!;
    public DateTime? EffectedFrom { get; set; } = default;
}
