using MediatR;
using Microsoft.AspNetCore.Mvc;
using Submission.Application.Features.CreateArticle;

namespace Submission.API.Endpoints.Articles;

public static class CreateArticleEndpoint
{
    public static void MapCreateArticleEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/articles", async (CreateArticleCommand createArticleCommand,[FromServices] ISender sender ) =>
            {
                var result = await sender.Send(createArticleCommand);
                return result.Id > 0
                    ? Results.Created($"/articles/{result.Id}", result)
                    : Results.BadRequest();
            })
            // .RequireAuthorization("AUT")
            .WithName("CreateArticle")
            .WithTags("Articles")
            .Produces(StatusCodes.Status201Created)
            .ProducesValidationProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status401Unauthorized);
    }
}