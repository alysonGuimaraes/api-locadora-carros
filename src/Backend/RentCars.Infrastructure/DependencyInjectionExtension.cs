using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentCars.Domain.Repositories;
using RentCars.Domain.Repositories.Car;
using RentCars.Infrastructure.DataAccess;
using RentCars.Infrastructure.DataAccess.Repositories;

namespace RentCars.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext_Postgres(services, configuration);
            AddRepositories(services, configuration);
        }

        private static void AddDbContext_Postgres(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionPostgres");

            services.AddDbContext<RentCarsDBContext>(dbContextOptions =>
            {
                dbContextOptions.UseNpgsql(connectionString);
            });
        }

        private static void AddRepositories(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitWork, WorkUnit>();

            services.AddScoped<ICarWriteOnlyRepository, CarRepository>();
            services.AddScoped<ICarReadOnlyRepository, CarRepository>();
        }
    }
}
