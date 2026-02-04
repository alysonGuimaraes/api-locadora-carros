using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RentCars.Infrastructure.DataAccess;

namespace WebApi.Test
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test")
                .ConfigureServices(services =>
                {
                    var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<RentCarsDBContext>));

                    if (descriptor is not null)
                        services.Remove(descriptor);

                    services.AddDbContext<RentCarsDBContext>(options =>
                    {
                        options.UseInMemoryDatabase("InMemoryDbForTesting");
                    });

                    var sp = services.BuildServiceProvider();
                    using (var scope = sp.CreateScope())
                    {
                        var db = scope.ServiceProvider.GetRequiredService<RentCarsDBContext>();
                        db.Cars.Add(new RentCars.Domain.Entities.Car
                        {
                            Model = "Test",
                            Brand = "Test",
                            Year = "1908",
                            License_Plate = "ABC1234"
                        });

                        db.SaveChanges();
                    }
                });
        }
    }
}
