using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLib.Extensions
{
    public static class ProductExtensions
    {
        public static ProductResponse ToResponse(this Product prd)
        {
            return new ProductResponse()
            {
                Id = prd.Id,
                Code = prd.Code,
                Name = prd.Name,
                Category = Enum.GetName<Category>(prd.Category),
                Price = prd.Pricings!.OrderBy(p=>p.EffectedFrom)?.LastOrDefault()?.Value
            };
        }
        public static ProductPricingResponse ToPricingsResponse(this Product prd)
        {
            return new ProductPricingResponse()
            {
                Id = prd.Id,
                Code = prd.Code,
                Name = prd.Name,
                Category = Enum.GetName<Category>(prd.Category),
                Pricings = prd.Pricings?.Select(p => p.ToResponse()).ToList()
            };
        }
        public static Product ToEntity(this ProductCreateReq req)
        {
            var category = Category.None;
            Category.TryParse(req.Category, out category);
            var entity = new Product()
            {
                Id = Guid.NewGuid().ToString(),
                Code = req.Code,
                Name = req.Name,
                Category = category,
                CreatedOn = DateTime.Now,
                LastUpdatedOn = null
            };
            var pricingReqs = req.Pricings?.Select(p => new PricingCreateReq()
            {
                ProductKey = entity.Id,
                Value = p.Value,
                EffectedFrom = p.EffectedFrom
            }).ToList();
            entity.Pricings = pricingReqs?.Select(p => p.ToEntity()).ToList();
            entity.Pricings?.ForEach(p => p.Product = entity);
            return entity;
        }
        public static void Copy(this Product prd, ProductUpdateReq req)
        {
            var category = Category.None;
            Category.TryParse(req.Category,out category);
            prd.Name = req.Name;
            prd.Category = category;
        }
    }
}
