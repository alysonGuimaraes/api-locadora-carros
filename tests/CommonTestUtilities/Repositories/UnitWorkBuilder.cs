using Moq;
using RentCars.Domain.Repositories;

namespace CommonTestUtilities.Repositories
{
    public class UnitWorkBuilder
    {
        public static IUnitWork Build()
        {
            var mock = new Mock<IUnitWork>();

            return mock.Object;
        }
    }
}
