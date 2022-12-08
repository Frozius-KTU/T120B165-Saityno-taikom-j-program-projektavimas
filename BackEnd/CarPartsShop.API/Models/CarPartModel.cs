using CarPartsShop.Core.Aggregates.CarModel;
using CarPartsShop.Core.Aggregates.CarPart;
using System.ComponentModel.DataAnnotations;

namespace CarPartsShop.API.Models;
public class CarPartModel
{
    public Guid Id { get; set; }
    [StringLength(32, ErrorMessage = "Car part name can't be longer than 32 symbols")]
    public string? Name { get; set; }

    [StringLength(256, ErrorMessage = "Car part description can't be longer than 256 symbols")]
    public string? Description { get; set; }
    public int Qty { get; set; }
    public CarModelModel? CarModel { get; set; }
    public CarPartEntity ToEntity() => new() { Id = Id, Name = Name, CarModelId = CarModel.Id, Description = Description, Qty = Qty};
}
