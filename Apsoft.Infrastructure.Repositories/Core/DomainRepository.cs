using Apsoft.Domain.Repositories.Core;

namespace Apsoft.Infrastructure.Repositories.Core;

// TODO: Da valutare se fare il mapping con Automapper o con un IMapper
// Questa classe è astratta per permettere di definire i metodi ToDomain e ToRecord
// Si potrebbe anche iniettare un IMapper per fare il mapping tra record e dominio
// Questo perche in Automapper non si dovrebber iniettare altri repository nel mapping.
// Tuttavia è possibile iniettare un IMapper in un DomainRepository e fare il mapping
// Quindi va valutare cosa fare.
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
        recordRepository.Insert(list.Select(ToRecord));
    }

    public void Update(IEnumerable<TDomain> list)
    {
        recordRepository.Update(list.Select(ToRecord));
    }

    public void Delete(IEnumerable<TDomain> list)
    {
        recordRepository.Delete(list.Select(ToRecord));
    }

    public void Merge(IEnumerable<TDomain> list)
    {
        recordRepository.Merge(list.Select(ToRecord));
    }

    public void Insert(TDomain item)
    {
        recordRepository.Insert(ToRecord(item));
    }

    public void Update(TDomain item)
    {
        recordRepository.Update(ToRecord(item));
    }

    public void Delete(TDomain item)
    {
        recordRepository.Delete(ToRecord(item));
    }

    public void Merge(TDomain item)
    {
        recordRepository.Merge(ToRecord(item));
    }

    public Task InsertAsync(IEnumerable<TDomain> list)
    {
        return recordRepository.InsertAsync(list.Select(ToRecord));
    }

    public Task UpdateAsync(IEnumerable<TDomain> list)
    {
        return recordRepository.UpdateAsync(list.Select(ToRecord));
    }

    public Task DeleteAsync(IEnumerable<TDomain> list)
    {
        return recordRepository.DeleteAsync(list.Select(ToRecord));
    }

    public Task MergeAsync(IEnumerable<TDomain> list)
    {
        return recordRepository.MergeAsync(list.Select(ToRecord));
    }

    public Task InsertAsync(TDomain item)
    {
        return recordRepository.InsertAsync(ToRecord(item));
    }

    public Task UpdateAsync(TDomain item)
    {
        return recordRepository.UpdateAsync(ToRecord(item));
    }

    public Task DeleteAsync(TDomain item)
    {
        return recordRepository.DeleteAsync(ToRecord(item));
    }

    public Task MergeAsync(TDomain item)
    {
        return recordRepository.MergeAsync(ToRecord(item));
    }

    protected abstract TDomain ToDomain(TRecord record);

    protected abstract TRecord ToRecord(TDomain entity);
}