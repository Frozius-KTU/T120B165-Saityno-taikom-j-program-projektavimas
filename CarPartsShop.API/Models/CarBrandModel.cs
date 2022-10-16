using CarPartsShop.Core.Aggregates.CarBrand;
using System.ComponentModel.DataAnnotations;

namespace CarPartsShop.API.Models;
public class CarBrandModel
{
    public Guid Id { get; set; }

    [StringLength(32, ErrorMessage = "Car brand name can't be longer than 32 symbols")]
    public string? Name { get; set; }
    public CarBrandEntity ToEntity() => new() { Id = Id, Name = Name };
}
