using Blocks.Domain.Entities;
using Blocks.EntityFrameworkCore.Repositories;
using Blocks.Exceptions;

namespace Blocks.EntityFrameworkCore.Extensions;

public static class RepositoryExtensions
{
    public static async Task<TEntity> FindByIdOrThrowAsync<TEntity , TContext>(this Repository<TContext,TEntity> repository, long id)
        where TEntity : class , IEntity
        where TContext : DbContext
    {
        var entity = await repository.FindByIdAsync(id);
        return entity ?? throw new NotFoundException($"{typeof(TEntity).Name} with id {id} not found");
    }
}