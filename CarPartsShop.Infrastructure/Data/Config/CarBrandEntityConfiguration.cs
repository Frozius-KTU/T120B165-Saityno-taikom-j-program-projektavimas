using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using CarPartsShop.Core.Aggregates.CarBrand;

namespace CarPartsShop.Infrastructure.Data.Config;

public abstract class CarBrandEntityConfiguration : BaseEntityConfiguration<CarBrandEntity>
{
    protected override void ConfigureEntity(EntityTypeBuilder<CarBrandEntity> builder)
    {
        builder.ToTable("CarBrands");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(32)
            .HasColumnType("nvarchar(32)");

    }
}
