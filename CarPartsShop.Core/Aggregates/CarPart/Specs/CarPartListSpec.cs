using Ardalis.Specification;

namespace CarPartsShop.Core.Aggregates.CarPart.Specs;
internal class CarPartListSpec : Specification<CarPartEntity>
{
    public CarPartListSpec()
    {
        Query
            .Include(x => x.CarModel)
            .ThenInclude(x => x.CarBrand);
    }
}
