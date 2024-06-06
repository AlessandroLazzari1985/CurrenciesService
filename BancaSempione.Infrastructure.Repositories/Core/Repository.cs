using Apsoft.Domain.Repositories.Core;
using Microsoft.EntityFrameworkCore;

namespace BancaSempione.Infrastructure.Repositories.Core;

public class Repository<T>(DbContext context) : IRepository<T>
    where T : class
{
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public void Delete()
    {
	    var tableName = context.Model.FindEntityType(typeof(T))?.GetSchemaQualifiedTableName()!;
	    var query = $"TRUNCATE TABLE {tableName}";
	    context.Database.ExecuteSqlRaw(query);
    }

    public void Insert(IEnumerable<T> list)
    {
	    context.BulkInsert(list, options =>
	    {
		    options.UnsafeMode = true;
		    options.AutoMapOutputDirection = false;
	    });
    }

    public void Update(IEnumerable<T> items)
    {
        context.BulkUpdate(items);
    }

    public void Delete(IEnumerable<T> list)
    {
        context.BulkDelete(list);
    }

    public void Merge(IEnumerable<T> list)
    {
        context.BulkMerge(list);
    }

    public void Insert(T item)
    {
        context.SingleInsert(item);
    }

    public void Update(T item)
    {
        context.SingleUpdate(item);
    }

    public void Delete(T item)
    {
        context.SingleDelete(item);
    }

    public void Merge(T item)
    {
        context.SingleMerge(item);
    }

    public async Task InsertAsync(IEnumerable<T> list)
    {
        await context.BulkInsertAsync(list, options => options.AutoMapOutputDirection = false);
    }

    public async Task UpdateAsync(IEnumerable<T> items)
    {
        await context.BulkUpdateAsync(items);
    }

    public async Task DeleteAsync(IEnumerable<T> list)
    {
        await context.BulkDeleteAsync(list);
    }

    public async Task MergeAsync(IEnumerable<T> list)
    {
        await context.BulkMergeAsync(list);
    }

    public async Task InsertAsync(T item)
    {
        await context.SingleInsertAsync(item);
    }

    public async Task UpdateAsync(T item)
    {
        await context.SingleUpdateAsync(item);
    }

    public async Task DeleteAsync(T item)
    {
        await context.SingleDeleteAsync(item);
    }

    public async Task MergeAsync(T item)
    {
        await context.SingleMergeAsync(item);
    }

    public IQueryable<T> Items => _dbSet.AsNoTracking();

}