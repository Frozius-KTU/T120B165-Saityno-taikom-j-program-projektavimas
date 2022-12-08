using Ardalis.Specification.EntityFrameworkCore;
using CarPartsShop.Shared.Interfaces;

namespace CarPartsShop.Infrastructure.Data;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    public EfRepository(DatabaseContext dbContext) : base(dbContext)
    {
    }
}

