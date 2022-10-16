using CarPartsShop.Core.Aggregates.CarModel;
using System.ComponentModel.DataAnnotations;

namespace CarPartsShop.API.Models;

public class CarModelModel
{
    public Guid Id { get; set; }
    public CarBrandModel? CarBrand { get; set; }

    [StringLength(32, ErrorMessage = "Car model name can't be longer than 32 symbols")]
    public string? Name { get; set; }
    public CarModelEntity ToEntity() => new() { Id = Id, Name = Name, CarBrandId = CarBrand.Id};
}
