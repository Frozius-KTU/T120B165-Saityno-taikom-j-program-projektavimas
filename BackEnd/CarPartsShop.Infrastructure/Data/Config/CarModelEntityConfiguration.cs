using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using CarPartsShop.Core.Aggregates.CarModel;

namespace CarPartsShop.Infrastructure.Data.Config;

public class CarModelEntityConfiguration : BaseEntityConfiguration<CarModelEntity>
{
    protected override void ConfigureEntity(EntityTypeBuilder<CarModelEntity> builder)
    {
        builder.ToTable("CarModels");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(32)
            .HasColumnType("nvarchar(32)");
        builder.HasOne(x => x.CarBrand)
            .WithMany()
            .HasForeignKey(x => x.CarBrandId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
            
    }
}
