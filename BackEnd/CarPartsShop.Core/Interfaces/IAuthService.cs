using CarPartsShop.Core.Aggregates.Auth;
using CarPartsShop.Shared.Interfaces;

namespace CarPartsShop.Core.Interfaces;
public interface IAuthService
{
    IRepository<ShopRestUser> Repository { get; }
    Task<ShopRestUser?> GetUserByUserId(string userId, CancellationToken cancellationToken = default);
}