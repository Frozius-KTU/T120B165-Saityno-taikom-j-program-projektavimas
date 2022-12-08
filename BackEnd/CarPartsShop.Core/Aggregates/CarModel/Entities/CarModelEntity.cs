using CarPartsShop.Core.Aggregates.Auth;
using CarPartsShop.Core.Aggregates.CarBrand;
using CarPartsShop.Shared.Interfaces;

namespace CarPartsShop.Core.Aggregates.CarModel;
public class CarModelEntity : BaseEntity, IAggregateRoot, IUserOwnedResource
{
    public string? Name { get; set; }
    public CarBrandEntity? CarBrand { get; set; }
    public Guid CarBrandId { get; set; }
    public string UserId { get; set; }
    public ShopRestUser User { get; set; }
    public void Update(CarModelEntity request)
    {
        Name = request.Name ?? Name;
        CarBrand = request.CarBrand ?? CarBrand;
        CarBrandId = request.CarBrandId;
    }
}
