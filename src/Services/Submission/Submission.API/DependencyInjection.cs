namespace Submission.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration config)
    {
        services
            .AddMemoryCache()
            .AddEndpointsApiExplorer()
            .AddSwaggerGen()
            ;
        
        return services;
    }
}