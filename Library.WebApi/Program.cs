using Library.Application.Interfaces;
using Library.Application;
using Library.Persistance;
using Library.WebApi;
using Library.WebApi.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        
        builder.Services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(IBooksDbContext).Assembly));
            config.AddProfile(new AssemblyMappingProfile(typeof(IAuthorDbContext).Assembly));
        });
        builder.Services.AddAplication();
        builder.Services.AddPersistence(builder.Configuration);
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
        });

        
        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            try
            {
                var context = serviceProvider.GetRequiredService<LibDbContext>();
                DbInitializer.Initialize(context);
            }
            catch (Exception exception)
            {

            }
        }

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwagger();
        app.UseSwaggerUI(config =>
        {
            config.RoutePrefix = string.Empty;
            config.SwaggerEndpoint("swagger/v1/swagger.json", "Lib API");
        });
        app.UseCustomExceptionHandler();
        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseCors("AllowAll");
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.Run();
    }
}
    
