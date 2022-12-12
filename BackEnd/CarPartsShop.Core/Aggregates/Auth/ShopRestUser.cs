using CarPartsShop.Shared.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CarPartsShop.Core.Aggregates.Auth;
public class ShopRestUser : IdentityUser, IAggregateRoot
{
    [PersonalData]  
    public string? AdditionalInfo { get; set; }
}
