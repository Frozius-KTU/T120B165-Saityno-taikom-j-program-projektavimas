namespace CarPartsShop.Shared.Interfaces;

public interface IRepository<T> : IReadRepository<T> where T : class, IAggregateRoot
{
}

