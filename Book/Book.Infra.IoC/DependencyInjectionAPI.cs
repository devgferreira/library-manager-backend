
using Book.Application.Interfaces;
using Book.Application.Service;
using Book.Domain.Contracts;
using Book.Infra.Data.Context;
using Book.Infra.Data.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Book.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddScoped<DbSession>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IBookRepository, BookRepository>();
            var myhandlers = configuration.GetSection("Book.Application");
            return services;
        }
    }
}
