using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentCars.Domain.Repositories;
using RentCars.Domain.Repositories.Car;
using RentCars.Infrastructure.DataAccess;
using RentCars.Infrastructure.DataAccess.Repositories;
using RentCars.Infrastructure.Extensions;
using System.Reflection;

namespace RentCars.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddRepositories(services);

            if (configuration.IsUnitTestEnvironment())
                return;

            AddDbContext_Postgres(services, configuration);
            AddFluentMigrator_Postgres(services, configuration);
        }

        private static void AddDbContext_Postgres(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.ConnectionString();

            services.AddDbContext<RentCarsDBContext>(dbContextOptions =>
            {
                dbContextOptions.UseNpgsql(connectionString);
            });
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitWork, WorkUnit>();

            services.AddScoped<ICarWriteOnlyRepository, CarRepository>();
            services.AddScoped<ICarReadOnlyRepository, CarRepository>();
        }

        private static void AddFluentMigrator_Postgres(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.ConnectionString();

            services.AddFluentMigratorCore().ConfigureRunner(options =>
            {
                options
                .AddPostgres()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(Assembly.Load("RentCars.Infrastructure")).For.All();
            });
        }
    }
}
