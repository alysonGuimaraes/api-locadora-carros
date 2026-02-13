using Microsoft.EntityFrameworkCore;
using RentCars.Domain.Entities;

namespace RentCars.Infrastructure.DataAccess
{
    public class RentCarsDBContext : DbContext
    {
        public RentCarsDBContext(DbContextOptions<RentCarsDBContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RentCarsDBContext).Assembly);
        }
    }
}
