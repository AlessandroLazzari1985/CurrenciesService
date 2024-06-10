using Apsoft.Domain.Repositories.Core;

namespace BancaSempione.Infrastructure.Repositories.Core;

public abstract class DomainRepository<TRecord, TDomain>(Repository<TRecord> recordRepository): IRepository<TDomain>
    where TRecord : class
    where TDomain : class
{
    public IQueryable<TDomain> Items => recordRepository.Items.AsEnumerable().Select(ToDomain).AsQueryable();
    public void Delete()
    {
        recordRepository.Delete();
    }

    public void Insert(IEnumerable<TDomain> list)
    {
        recordRepository.Insert(list.Select(FromDomain));
    }

    public void Update(IEnumerable<TDomain> list)
    {
        recordRepository.Update(list.Select(FromDomain));
    }

    public void Delete(IEnumerable<TDomain> list)
    {
        recordRepository.Delete(list.Select(FromDomain));
    }

    public void Merge(IEnumerable<TDomain> list)
    {
        recordRepository.Merge(list.Select(FromDomain));
    }

    public void Insert(TDomain item)
    {
        recordRepository.Insert(FromDomain(item));
    }

    public void Update(TDomain item)
    {
        recordRepository.Update(FromDomain(item));
    }

    public void Delete(TDomain item)
    {
        recordRepository.Delete(FromDomain(item));
    }

    public void Merge(TDomain item)
    {
        recordRepository.Merge(FromDomain(item));
    }

    public Task InsertAsync(IEnumerable<TDomain> list)
    {
        return recordRepository.InsertAsync(list.Select(FromDomain));
    }

    public Task UpdateAsync(IEnumerable<TDomain> list)
    {
        return recordRepository.UpdateAsync(list.Select(FromDomain));
    }

    public Task DeleteAsync(IEnumerable<TDomain> list)
    {
        return recordRepository.DeleteAsync(list.Select(FromDomain));
    }

    public Task MergeAsync(IEnumerable<TDomain> list)
    {
        return recordRepository.MergeAsync(list.Select(FromDomain));
    }

    public Task InsertAsync(TDomain item)
    {
        return recordRepository.InsertAsync(FromDomain(item));
    }

    public Task UpdateAsync(TDomain item)
    {
        return recordRepository.UpdateAsync(FromDomain(item));
    }

    public Task DeleteAsync(TDomain item)
    {
        return recordRepository.DeleteAsync(FromDomain(item));
    }

    public Task MergeAsync(TDomain item)
    {
        return recordRepository.MergeAsync(FromDomain(item));
    }

    protected abstract TDomain ToDomain(TRecord record);

    protected abstract TRecord FromDomain(TDomain divisa);
}