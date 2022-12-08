namespace CarPartsShop.Core.Aggregates.Auth;
public static class ShopRoles
{
    public const string Admin = nameof(Admin);
    public const string ShopUser = nameof(ShopUser);

    public static readonly IReadOnlyCollection<string> All = new[] { Admin, ShopUser };
}
