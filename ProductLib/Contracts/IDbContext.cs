using Microsoft.EntityFrameworkCore;

namespace ProductLib
{
    public interface IDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Pricing> Pricings { get; set; }
        int SaveChanges();
    }
}