
using OrderManagement.Application.Installers;
using OrderManagement.Core.Database;
using OrderManagement.Core.Installers;
using Wolverine;
using Wolverine.Http;
using Wolverine.Transports.Tcp;

namespace OrderManagementService
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.InstallCore();
            builder.Services.InstallApplication();

            builder.Host.UseWolverine(opts => opts.PublishAllMessages().ToPort(8010));


            var app = builder.Build();

            // ensure database and tables exist
            {
                using var scope = app.Services.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                await context.Init();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapWolverineEndpoints();

            app.Run();
        }
    }
}
