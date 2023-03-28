using Library.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistance
{
     public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence (this IServiceCollection
            services , IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<LibDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<IBooksDbContext>(provider =>
                    provider.GetService<LibDbContext>());

            services.AddScoped<IAuthorDbContext>(provider =>
                    provider.GetService<LibDbContext>());
            return services;
        }
    }
}
