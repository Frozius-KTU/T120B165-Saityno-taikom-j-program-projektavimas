using Ardalis.Specification;

namespace CarPartsShop.Core.Aggregates.CarPart.Specs;
internal class CarPartsByModelIdSpec : Specification<CarPartEntity>
{
    public CarPartsByModelIdSpec(Guid modelId)
    {
        Query
            .Where(x => x.CarModel.Id == modelId)
            .Include(x => x.CarModel)
            .ThenInclude(x => x.CarBrand);
    }
}
