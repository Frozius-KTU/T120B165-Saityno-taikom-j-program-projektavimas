using Ardalis.Specification;

namespace CarPartsShop.Core.Aggregates.CarPart.Specs;
internal class CarPartByBrandIdSpec : Specification<CarPartEntity>
{
    public CarPartByBrandIdSpec(Guid carBrandID, Guid carModelId)
    {
        Query
            .Where(x => x.CarModel.CarBrandId == carBrandID && x.CarModelId == carModelId)
            .Include(x => x.CarModel)
            .ThenInclude(x => x.CarBrand);
    }
}
