namespace RentCars.Domain.Repositories.Car
{
    public interface ICarReadOnlyRepository
    {
        public Task<bool> ExistActiveCarWithPlate(string plate);
    }
}
