using Apsoft.Domain.Repositories.Core;
using Microsoft.EntityFrameworkCore;

namespace BancaSempione.Infrastructure.Repositories.Core;

public class Repository<T>(DbContext context) : IRepository<T>
    where T : class
{
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public virtual IQueryable<T> Items => _dbSet.AsNoTracking();

    public void Delete()
    {
	    var tableName = context.Model.FindEntityType(typeof(T))?.GetSchemaQualifiedTableName()!;
	    var query = $"TRUNCATE TABLE {tableName}";
	    context.Database.ExecuteSqlRaw(query);
    }

    public virtual void Insert(IEnumerable<T> list)
    {
	    context.BulkInsert(list, options =>
	    {
		    options.UnsafeMode = true;
		    options.AutoMapOutputDirection = false;
	    });
    }

    public virtual void Update(IEnumerable<T> items)
    {
        context.BulkUpdate(items);
    }

    public virtual void Delete(IEnumerable<T> list)
    {
        context.BulkDelete(list);
    }

    public virtual void Merge(IEnumerable<T> list)
    {
        context.BulkMerge(list);
    }

    public virtual void Insert(T item)
    {
        context.SingleInsert(item);
    }

    public virtual void Update(T item)
    {
        context.SingleUpdate(item);
    }

    public virtual void Delete(T item)
    {
        context.SingleDelete(item);
    }

    public virtual void Merge(T item)
    {
        context.SingleMerge(item);
    }

    public virtual async Task InsertAsync(IEnumerable<T> list)
    {
        await context.BulkInsertAsync(list, options => options.AutoMapOutputDirection = false);
    }

    public virtual async Task UpdateAsync(IEnumerable<T> items)
    {
        await context.BulkUpdateAsync(items);
    }

    public virtual async Task DeleteAsync(IEnumerable<T> list)
    {
        await context.BulkDeleteAsync(list);
    }

    public virtual async Task MergeAsync(IEnumerable<T> list)
    {
        await context.BulkMergeAsync(list);
    }

    public virtual async Task InsertAsync(T item)
    {
        await context.SingleInsertAsync(item);
    }

    public virtual async Task UpdateAsync(T item)
    {
        await context.SingleUpdateAsync(item);
    }

    public virtual async Task DeleteAsync(T item)
    {
        await context.SingleDeleteAsync(item);
    }

    public virtual async Task MergeAsync(T item)
    {
        await context.SingleMergeAsync(item);
    }
}