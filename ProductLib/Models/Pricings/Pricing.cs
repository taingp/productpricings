namespace ProductLib;

public class Pricing
    :PricingBase
    , IKey
{
    public string Id { get; set; } = default!;
    public string ProductId { get; set; } = default!;
    public DateTime EffectedFrom { get;set; } = default!;
    public DateTime? CreatedOn { get;set; } = default!;
    public DateTime? LastUpdatedOn { get; set; } = default!;

    public Product? Product { get; set; } = default;
}
