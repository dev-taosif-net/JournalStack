using Blocks.MediatR.Behaviours;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Submission.Application.Features.CreateArticle;

namespace Submission.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services
            .AddValidatorsFromAssemblyContaining<CreateArticleCommandValidator>()        // Register Fluent validators as transient
            .AddMediatR(cfg =>
                {
                    cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
                }
            )
            ;

        return services;
    }
}