using CarPartsShop.Core.Aggregates.Auth;
using CarPartsShop.Shared.Interfaces;

namespace CarPartsShop.Core.Aggregates.CarBrand;
public class CarBrandEntity : BaseEntity, IAggregateRoot, IUserOwnedResource
{
    public string Name { get; set; }
    public string UserId { get; set; }
    public void Update(CarBrandEntity request)
    {
        Name = request.Name ?? Name;
}
}
