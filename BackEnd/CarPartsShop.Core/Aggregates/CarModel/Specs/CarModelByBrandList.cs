using Ardalis.Specification;

namespace CarPartsShop.Core.Aggregates.CarModel.Specs;
public class CarModelByBrandList : Specification<CarModelEntity>
{
    public CarModelByBrandList(Guid id)
    {
        Query
            .Where(x => x.CarBrandId == id)
            .Include(x => x.CarBrand);
    }
}
