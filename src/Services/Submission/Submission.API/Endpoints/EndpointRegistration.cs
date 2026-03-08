using Submission.API.Endpoints.Articles;

namespace Submission.API.Endpoints;

public static class EndpointRegistration
{
    public static IEndpointRouteBuilder MapAllEndpoints(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("/api");
        
        api.MapCreateArticleEndpoint();
        
        return app;
    }

}