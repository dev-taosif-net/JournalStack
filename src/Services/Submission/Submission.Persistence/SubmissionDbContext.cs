namespace Submission.Persistence;

public class SubmissionDbContext : DbContext
{
    #region Entities
    
    public virtual DbSet<Domain.Entities.Journal> Journals {get; set;}
    public virtual DbSet<Domain.Entities.Article> Articles {get; set;}
    
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}