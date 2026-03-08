using Articles.Abstractions;
using MediatR;
using Submission.Domain.Entities;
using Submission.Persistence.Repositories;

namespace Submission.Application.Features.CreateArticle;

public class CreateArticleCommandHandler(Repository<Journal> journalRepository ) : IRequestHandler<CreateArticleCommand, IdResponse>
{
    public async Task<IdResponse> Handle(CreateArticleCommand command, CancellationToken cancellationToken)
    {
        var journal = await journalRepository.FindByIdAsync(command.JournalId);
        var article = journal?.CreateArticle(command.Title, command.Type, command.Scope);
        await  journalRepository.SaveChangesAsync(cancellationToken);

        return new IdResponse(article?.Id??0);
    }
}