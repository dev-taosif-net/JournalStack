namespace Submission.Domain.Entities;

public partial class Journal
{
    public long Id { get; init; }
    public required string Name { get; set; }
    public required string Abbreviation { get; set; }
    
    private readonly List<Article> _articles = [];
    public IReadOnlyList<Article> Articles => _articles.AsReadOnly();
}