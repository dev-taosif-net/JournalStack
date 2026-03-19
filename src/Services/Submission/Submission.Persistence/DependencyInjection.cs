using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Submission.Persistence.Repositories;

namespace Submission.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("Database");

        services.AddDbContext<SubmissionDbContext>(( provider, options) =>
        {
            options.UseSqlServer(connectionString);
        });
        
        services.AddScoped(typeof(Repository<>));
        services.AddScoped<ArticleRepository>();
        
        return services;
    }
}