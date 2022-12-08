using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPartsShop.Core.Aggregates.CarPart.Specs;
internal class CarPartsByBrandIdSpec : Specification<CarPartEntity>
{
    public CarPartsByBrandIdSpec(Guid carBrandID)
    {
        Query
            .Where(x => x.CarModel.CarBrandId == carBrandID)
            .Include(x => x.CarModel)
            .ThenInclude(x => x.CarBrand);
    }
}

