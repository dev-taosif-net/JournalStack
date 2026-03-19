namespace Submission.Domain.Entities;

public class ArticleActor
{
    public long ArticleId { get; init; }
    public long PersonId { get; init; }
    public Person Person { get; init; } = null!;
    public int Role { get; init; }
    
}