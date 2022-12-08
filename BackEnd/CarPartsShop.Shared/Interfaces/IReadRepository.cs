using Ardalis.Specification;

namespace CarPartsShop.Shared.Interfaces;

public interface IReadRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}

