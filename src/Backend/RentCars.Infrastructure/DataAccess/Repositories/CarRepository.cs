using Microsoft.EntityFrameworkCore;
using RentCars.Domain.Entities;
using RentCars.Domain.Repositories.Car;

namespace RentCars.Infrastructure.DataAccess.Repositories
{
    public class CarRepository : ICarWriteOnlyRepository, ICarReadOnlyRepository
    {
        private readonly RentCarsDBContext _dbContext;

        public CarRepository(RentCarsDBContext dbContext) => _dbContext = dbContext;

        public async Task Add(Car car)
        {
            await _dbContext.Cars.AddAsync(car);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistActiveCarWithPlate(string plate)
        {
            return await _dbContext.Cars.AnyAsync(car => car.License_Plate.Equals(plate) && car.Active);
        }
    }
}
