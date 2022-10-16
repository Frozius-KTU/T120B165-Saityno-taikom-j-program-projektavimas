using Ardalis.Specification;

namespace CarPartsShop.Core.Aggregates.CarModel.Specs;
public class CarModelListSpec : Specification<CarModelEntity>
{
    public CarModelListSpec()
    {
        Query
            .Include(x => x.CarBrand);
    }
}
