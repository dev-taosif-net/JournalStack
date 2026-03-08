using Blocks.Domain.Entities;
using Blocks.EntityFrameworkCore.Repositories;

namespace Submission.Persistence.Repositories;

public class Repository<TEntity>(SubmissionDbContext context)
    : Repository<SubmissionDbContext, TEntity> (context)
    where TEntity : class , IEntity
{
}