namespace Submission.Persistence;

public class SubmissionDbContext(DbContextOptions<SubmissionDbContext> options) : DbContext(options)
{
    #region Entities
    
    public virtual DbSet<Domain.Entities.Journal> Journals {get; set;}
    public virtual DbSet<Domain.Entities.Article> Articles {get; set;}
    
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}