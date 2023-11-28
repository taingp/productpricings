namespace ProductLib;

public class PricingCreateReq
    :PricingBase
    , ICreateReq
{
    public string ProductKey { get; set; } = default!;
    public DateTime? EffectedFrom { get; set; } = default;
}
