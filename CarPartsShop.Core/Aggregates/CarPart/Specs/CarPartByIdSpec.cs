using Ardalis.Specification;
using CarPartsShop.Core.Aggregates.CarPart;

namespace CarPartsShop.Core.Aggregates.CarModel.Specs;
public class CarPartByIdSpec : Specification<CarPartEntity>, ISingleResultSpecification<CarPartEntity>
{
    public CarPartByIdSpec(Guid id)
    {
        Query
            .Where(x => x.Id == id)
            .Include(x => x.CarModel)
            .ThenInclude(x => x.CarBrand);
    }
}
