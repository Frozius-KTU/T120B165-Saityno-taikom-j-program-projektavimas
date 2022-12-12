using CarPartsShop.Core.Aggregates.CarModel;
using CarPartsShop.Core.Aggregates.CarPart;
using System.ComponentModel.DataAnnotations;

namespace CarPartsShop.API.Models;
public class CarPartModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }

    public string? Description { get; set; }
    public int Qty { get; set; }
    public string PhotoUrl { get; set; }
    public CarModelModel? CarModel { get; set; }
    public CarPartEntity ToEntity() => new() { Id = Id, Name = Name, CarModelId = CarModel.Id, Description = Description, Qty = Qty, PhotoUrl = PhotoUrl};
}
