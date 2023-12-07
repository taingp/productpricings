namespace ProductLib;

public class PricingReqFU
    : PricingBase
    , IKey
{
    public string Id { get; set; } = default!;
    public DateTime? EffectedFrom { get; set; } = default;
}
