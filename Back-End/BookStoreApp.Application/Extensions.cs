using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace BookStoreApp.Application
{
    public static class Extensions
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());


            return services;
        }
    }
}
