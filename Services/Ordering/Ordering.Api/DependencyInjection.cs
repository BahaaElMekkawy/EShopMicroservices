namespace Ordering.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        //Add Services for the API layer here
        return services;
    }
    public static WebApplication UseApiServices(this WebApplication app)
    {
        //Add Services for the API layer here
        return app;
    }

}
