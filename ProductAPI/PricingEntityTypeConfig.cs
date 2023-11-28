using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductLib;

namespace ProductApi;

public class PricingEntityTypeConfig : IEntityTypeConfiguration<Pricing>
{
    public void Configure(EntityTypeBuilder<Pricing> builder)
    {
        builder.ToTable("Pricings");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired(true)
            .HasColumnName(nameof(Pricing.Id))
            .HasColumnType("varchar")
            .HasMaxLength(36)
            .IsUnicode(false)
            ;

        builder.Property(x => x.Id)
            .IsRequired(true)
            .HasColumnName(nameof(Pricing.Id))
            .HasColumnType("varchar")
            .HasMaxLength(36)
            .IsUnicode(false)
            ;

        builder.Property(x => x.Value)
            .IsRequired(true)
            .HasColumnName(nameof(Pricing.Value))
            .HasColumnType("decimal(18,5)")
            ;

        builder.Property(x => x.EffectedFrom)
            .IsRequired(true)
            .HasColumnName(nameof(Pricing.EffectedFrom))
            .HasColumnType("datetime")
            ;

        builder.Property(x => x.CreatedOn)
            .IsRequired(false)
            .HasColumnName(nameof(Pricing.CreatedOn))
            .HasColumnType("datetime")
            ;

        builder.Property(x => x.LastUpdatedOn)
            .IsRequired(false)
            .HasColumnName(nameof(Pricing.LastUpdatedOn))
            .HasColumnType("datetime")
            ;

        builder.HasOne(x => x.Product)
               .WithMany(p => p.Pricings)
               .HasForeignKey(x => x.ProductId)
               .HasPrincipalKey(x => x.Id)
               .OnDelete(DeleteBehavior.NoAction)
               ;
    }
}
