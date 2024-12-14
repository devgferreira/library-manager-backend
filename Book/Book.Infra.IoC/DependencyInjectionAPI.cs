
using Book.Infra.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionAPI
{
    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
    IConfiguration configuration)
    {


        services.AddScoped<DbSession>();
        var myhandlers = configuration.GetSection("Book.Application");
        return services;
    }
}