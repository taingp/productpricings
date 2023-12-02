namespace ProductLib;

public class PricingRepo 
    : Repo<Pricing>
    , IPricingRepo
{
    public PricingRepo(IDbContext context) : base(context) { }
}
