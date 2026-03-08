namespace Blocks.EntityFrameworkCore.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    // Core
    Task<TEntity?> GetByIdAsync(long id, CancellationToken ct = default);
    // Task<bool> ExistsAsync(TKey id, CancellationToken ct = default);
    // Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken ct = default);
    TEntity Update(TEntity entity);
    void Remove(TEntity entity);
    Task<bool> DeleteByIdAsync(long id, CancellationToken ct = default);
    
    
    // Unit of work bits
    Task<int> SaveChangesAsync(CancellationToken ct = default);
    void ClearTracking();
}