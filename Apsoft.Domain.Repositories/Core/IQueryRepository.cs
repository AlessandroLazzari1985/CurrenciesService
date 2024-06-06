namespace Apsoft.Domain.Repositories.Core;

public interface IQueryRepository<out T>
    where T : class
{
    IQueryable<T> Items { get; }
}