namespace ProductLib;

public class PricingUpdateReq
    :PricingBase
    ,IUpdateReq
    , IKey
{
    public string Id { get; set; } = default!;
    public string ProductKey { get; set; } = default!;
    public DateTime? EffectedFrom { get; set; } = default;
}
