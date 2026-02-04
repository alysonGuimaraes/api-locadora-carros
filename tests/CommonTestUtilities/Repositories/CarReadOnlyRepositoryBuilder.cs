using Moq;
using RentCars.Domain.Repositories.Car;

namespace CommonTestUtilities.Repositories
{
    public class CarReadOnlyRepositoryBuilder
    {
        private readonly Mock<ICarReadOnlyRepository> _repository;

        public CarReadOnlyRepositoryBuilder() => _repository = new Mock<ICarReadOnlyRepository>();

        public void ExistActiveCarWithPlate(string plate)
        {
            _repository.Setup(repository => repository.ExistActiveCarWithPlate(plate)).ReturnsAsync(true);
        }

        public ICarReadOnlyRepository Build()
        {
            return _repository.Object;
        }
    }
}
