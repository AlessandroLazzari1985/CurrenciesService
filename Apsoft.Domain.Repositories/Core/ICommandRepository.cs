namespace Apsoft.Domain.Repositories.Core;

public interface ICommandRepository<in T>
    where T : class
{
    void Delete();

    #region sync

    #region Bulk
    void Insert(IEnumerable<T> list);
    void Update(IEnumerable<T> list);
    void Delete(IEnumerable<T> list);
    void Merge(IEnumerable<T> list);
    #endregion

    #region Single
    void Insert(T item);
    void Update(T item);
    void Delete(T item);
    void Merge(T item);
    #endregion

    #endregion

    #region async

    #region Bulk
    Task InsertAsync(IEnumerable<T> list);
    Task UpdateAsync(IEnumerable<T> list);
    Task DeleteAsync(IEnumerable<T> list);
    Task MergeAsync(IEnumerable<T> list);
    #endregion

    #region Single
    Task InsertAsync(T item);
    Task UpdateAsync(T item);
    Task DeleteAsync(T item);
    Task MergeAsync(T item);
    #endregion

    #endregion

}