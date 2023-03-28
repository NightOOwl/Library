using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using FluentValidation;


namespace Library.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication (this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));          
            return services;
        }
    }
}
