using Ardalis.Specification;

namespace CarPartsShop.Core.Aggregates.CarModel.Specs;
public class CarModelByIdSpec : Specification<CarModelEntity>, ISingleResultSpecification<CarModelEntity>
{
    public CarModelByIdSpec(Guid id)
    {
        Query
            .Where(x => x.Id == id)
            .Include(x => x.CarBrand);
    }
}
