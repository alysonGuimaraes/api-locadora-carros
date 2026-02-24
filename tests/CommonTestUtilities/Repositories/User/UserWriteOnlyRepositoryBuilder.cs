
using Moq;
using RentCars.Domain.Repositories.User;

namespace CommonTestUtilities.Repositories.User
{
    public class UserWriteOnlyRepositoryBuilder
    {
        public static IUserWriteOnlyRepository Build()
        {
            var mock = new Mock<IUserWriteOnlyRepository>();

            return mock.Object;
        }
    }
}
