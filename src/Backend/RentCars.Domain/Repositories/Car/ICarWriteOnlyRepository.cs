namespace RentCars.Domain.Repositories.Car
{
    public interface ICarWriteOnlyRepository
    {
        public Task Add(Entities.Car car);
    }
}
