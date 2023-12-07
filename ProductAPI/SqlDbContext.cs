using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductLib;
using ProductLib.Extensions;
using System.Reflection.Emit;

namespace ProductApi;

public class SqlDbContext : DbContext, IDbContext
{
    public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductEntityTypeConfig());
        modelBuilder.ApplyConfiguration(new PricingEntityTypeConfig());
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        var prdReqs = new List<ProductCreateReq>()
        {
            new()
            {
                Code = "PRD001",
                Name = "Coca",
                Category= "Food",
            },
            new()
            {
                Code = "PRD002",
                Name = "Dream 125",
                Category= "Vehicle",
            },
            new()
            {
                Code = "PRD003",
                Name = "TShirt-SEA game 2023",
                Category= "Cloth",
            }
        };
        var prdEntities = prdReqs.Select(x => x.ToEntity()).ToList();
        modelBuilder.Entity<Product>().HasData(prdEntities);
 
        DateTime? effectedDate = DateTime.Now;
        var pricingReqs = new List<PricingCreateReq>()
        {
            new()
            {
                EffectedFrom = effectedDate,
                Value = 8.5,
            },
            new()
            {
                EffectedFrom = effectedDate,
                Value = 2350.0,
            },
            new()
            {
                EffectedFrom = effectedDate,
                Value = 5.0,

            }
        };
        var pricingEntities = pricingReqs.Select(x => x.ToEntity()).ToList();
        
        int MaxElements = Math.Max(prdEntities.Count(), pricingEntities.Count());
        for (int index = 0; index < MaxElements; index++)
        {
            pricingEntities[index].ProductId = prdEntities[index].Id;
        }
        modelBuilder.Entity<Pricing>().HasData(pricingEntities);
    }
}
