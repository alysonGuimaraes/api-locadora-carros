using RentCars.Domain.Repositories;

namespace RentCars.Infrastructure.DataAccess
{
    public class WorkUnit : IUnitWork
    {
        private readonly RentCarsDBContext _dbContext;

        public WorkUnit(RentCarsDBContext dbContext) => _dbContext = dbContext;

        public async Task Commit() => await _dbContext.SaveChangesAsync();
    }
}
