using Articles.Abstractions.Enums;
using Blocks.Domain.Entities;


namespace Submission.Domain.Entities;

public partial class Article : IEntity
{
    public long Id { get; init; }
    public required string Title { get; set; }
    public required string Scope { get; set; }
    public required ArticleType Type { get; set; }
    public ArticleStage Stage { get; internal set; }
    public long JournalId { get; set; }
    public required Journal Journal { get; set; }
}