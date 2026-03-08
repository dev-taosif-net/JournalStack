using Blocks.Domain.Entities;

namespace Blocks.EntityFrameworkCore.Repositories;

public class Repository<TContext , TEntity>(TContext context, DbSet<TEntity> dbSet)
    where TContext : DbContext
    where TEntity : class, IEntity
    
{
    private DbSet<TEntity> Entity => dbSet;
    protected virtual IQueryable<TEntity> Query() => dbSet;
    public virtual IQueryable<TEntity> QueryNotTracked() => dbSet.AsNoTracking();

    private string TableName => context.Model.FindEntityType(typeof(TEntity))?.GetTableName()!;
    
    
    public virtual async Task<TEntity?> FindByIdAsync(long id)
    {
        return await Entity.FindAsync( id);
    }
    
    public virtual async Task<TEntity?> GetByIdAsync(long id, CancellationToken ct = default)
    {
        return await Query().SingleOrDefaultAsync(e => e.Id == id, ct);
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken ct = default)
    {
        var entry = await dbSet.AddAsync(entity, ct);
        return entry.Entity;
    }

    public virtual TEntity Update(TEntity entity)
    {
        var entry = Entity.Update(entity);
        return entry.Entity;
    }

    public virtual void Remove(TEntity entity)
    {
        Entity.Remove(entity);
    }

    public virtual async Task<bool> DeleteByIdAsync(long id, CancellationToken ct = default)
    {
        var rows = await context.Database.ExecuteSqlInterpolatedAsync(
            $"DELETE FROM {TableName} WHERE Id = {id}", ct);
        return rows > 0;
    }
    
    
    public virtual async Task<int> SaveChangesAsync(CancellationToken ct = default)
        => await context.SaveChangesAsync(ct);
}