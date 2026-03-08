using Blocks.Domain.Entities;

namespace Blocks.EntityFrameworkCore.Repositories;

public interface IRepository<TEntity> where TEntity : class , IEntity
{
    // Core
    Task<TEntity?> GetByIdAsync(long id, CancellationToken ct = default);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken ct = default);
    TEntity Update(TEntity entity);
    void Remove(TEntity entity);
    Task<bool> DeleteByIdAsync(long id, CancellationToken ct = default);
    
    
    // Unit of work bits
    Task<int> SaveChangesAsync(CancellationToken ct = default);

}