using Articles.Abstractions.Enums;

namespace Submission.Domain.Entities;

public partial class Article
{
    public long Id { get; init; }
    public required string Title { get; set; }
    public required string Scope { get; set; }
    public required ArticleType Type { get; set; }
    public ArticleStage Stage { get; internal set; }
    public long JournalId { get; set; }
    public required Journal Journal { get; set; }
}