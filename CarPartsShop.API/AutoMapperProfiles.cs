using AutoMapper;
using CarPartsShop.API.Models;
using CarPartsShop.Core.Aggregates.CarBrand;
using CarPartsShop.Core.Aggregates.CarModel;
using CarPartsShop.Core.Aggregates.CarPart;
using CarPartsShop.Core.Common;

namespace CarPartsShop.API;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap(typeof(IPaginatedCollection<>), typeof(PaginatedList<>));
        CreateMap<CarBrandEntity, CarBrandModel>().ReverseMap();
        CreateMap<CarModelEntity, CarModelModel>().ReverseMap();
        CreateMap<CarPartEntity, CarPartModel>().ReverseMap();
    }
}
