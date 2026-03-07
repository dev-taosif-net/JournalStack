using Articles.Abstractions;
using Articles.Abstractions.Enums;
using FluentValidation;
using MediatR;

namespace Submission.Application.Features.CreateArticle;

public record CreateArticleCommand(int JournalId, string Title , string Scope, ArticleType Type) : IRequest<IdResponse>;

public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
{
    public CreateArticleCommandValidator()
    {
        RuleFor(x => x.JournalId).GreaterThan(0);
        RuleFor(x => x.Title).NotEmpty().MaximumLength(255);
        RuleFor(x => x.Scope).NotEmpty().MaximumLength(1000);
    }
}