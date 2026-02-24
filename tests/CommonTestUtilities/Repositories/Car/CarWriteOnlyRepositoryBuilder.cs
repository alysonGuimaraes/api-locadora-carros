using Moq;
using RentCars.Domain.Repositories.Car;

namespace CommonTestUtilities.Repositories.Car
{
    public class CarWriteOnlyRepositoryBuilder
    {
        public static ICarWriteOnlyRepository Build()
        {
            var mock = new Mock<ICarWriteOnlyRepository>();

            return mock.Object;
        }
    }
}
