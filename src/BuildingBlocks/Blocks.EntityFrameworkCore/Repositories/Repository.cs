using Blocks.Domain.Entities;

namespace Blocks.EntityFrameworkCore.Repositories;

public class Repository<TContext, TEntity>
    where TContext : DbContext
    where TEntity : class, IEntity
    
{
    private readonly TContext _dbContext;
    private readonly DbSet<TEntity> _entity;

    public Repository(TContext dbContext)
    {
        this._dbContext = dbContext;
        this._entity = dbContext.Set<TEntity>();
    }
    
    public TContext DbContext => _dbContext;
    public virtual DbSet<TEntity> Entities => _entity;
    protected virtual IQueryable<TEntity> Query() => _entity;
    public virtual IQueryable<TEntity> QueryNotTracked() => _entity.AsNoTracking();
    private string TableName => _dbContext.Model.FindEntityType(typeof(TEntity))?.GetTableName()!;
    
    
    public virtual async Task<TEntity?> FindByIdAsync(long id)
    {
        return await _entity.FindAsync( id);
    }
    public virtual async Task<TEntity?> GetByIdAsync(long id, CancellationToken ct = default)
    {
        return await Query().SingleOrDefaultAsync(e => e.Id == id, ct);
    }
    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken ct = default)
    {
        var entry = await _entity.AddAsync(entity, ct);
        return entry.Entity;
    }
    public virtual TEntity Update(TEntity entity)
    {
        var entry = _entity.Update(entity);
        return entry.Entity;
    }
    public virtual void Remove(TEntity e)
    {
        _entity.Remove(e);
    }
    public virtual async Task<bool> DeleteByIdAsync(long id, CancellationToken ct = default)
    {
        var rows = await _dbContext.Database.ExecuteSqlInterpolatedAsync(
            $"DELETE FROM {TableName} WHERE Id = {id}", ct);
        return rows > 0;
    }
    public virtual async Task<int> SaveChangesAsync(CancellationToken ct = default)
        => await _dbContext.SaveChangesAsync(ct);
}