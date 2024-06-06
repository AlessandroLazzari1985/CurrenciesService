namespace Apsoft.Domain.Repositories.Core;

public interface IRepository<T> : IQueryRepository<T>, ICommandRepository<T>
    where T : class
{

}