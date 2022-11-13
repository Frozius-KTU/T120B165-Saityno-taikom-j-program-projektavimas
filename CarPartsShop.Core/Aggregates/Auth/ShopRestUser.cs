using Microsoft.AspNetCore.Identity;

namespace CarPartsShop.Core.Aggregates.Auth;
public class ShopRestUser : IdentityUser
{
    [PersonalData]  
    public string? AdditionalInfo { get; set; }
}
