using Ardalis.Specification;

namespace CarPartsShop.Core.Aggregates.CarPart.Specs;
internal class CarPartsByUserIdSpec : Specification<CarPartEntity>
{
    public CarPartsByUserIdSpec(Guid userId)
    {
        Query
            .Where(x => x.UserId == userId.ToString())
            .Include(x => x.CarModel)
                .ThenInclude(x => x.CarBrand);

    }
}
