namespace ProductLib.Extensions
{
    public static class PricingExtensions
    {
        public static PricingResponse ToResponse(this Pricing pricing)
        {
            return new PricingResponse()
            {
                Id = pricing.Id,
                ProductCode = pricing.Product!.Code,
                Value = pricing.Value,
                EffectedFrom = pricing.EffectedFrom,
            };
        }
        public static Pricing ToEntity(this PricingCreateReq req)
        {
            DateTime actingDate = DateTime.Now;
            return new Pricing()
            {
                Id = Guid.NewGuid().ToString(),
                ProductId = req.ProductKey,
                Value = req.Value,
                EffectedFrom = req.EffectedFrom??actingDate,
                CreatedOn = actingDate,
                LastUpdatedOn = null
            };
        }
        public static void Copy(this Pricing pricing, PricingUpdateReq req)
        {
            pricing.ProductId = req.ProductKey;
            pricing.Value = req.Value;
            pricing.ProductId = req.ProductKey;
            pricing.EffectedFrom = req.EffectedFrom ?? DateTime.Now;
        }
    }
}
