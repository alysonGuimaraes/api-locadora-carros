
using CommonTestUtilities.Cryptography;
using CommonTestUtilities.Repositories.User;
using CommonTestUtilities.Requests.Login;
using RentCars.Domain.Entities;
using RentCars.Application.UseCases.Login.DoLogin;
using RentCars.Exceptions;
using RentCars.Exceptions.ExceptionsBase;
using CommonTestUtilities.Entities;
using RentCars.Communication.Requests;

namespace UseCases.Test.Login.DoLogin
{
    public class DoLoginUseCaseTest
    {

        [Fact]
        public async Task Success()
        {
            (var user, var password) = UserBuilder.Build();

            var useCase = CreateUseCase(user);

            var request = new RequestLoginJson { Email = user.Email, Password = password };

            var result = await useCase.Execute(request);

            Assert.NotNull(result);
            Assert.Equal(user.Name, result.Name);
        }

        [Fact]
        public async Task Error_Invalid_User()
        {
            var request = RequestLoginJsonBuilder.Build();

            var useCase = CreateUseCase();

            Func<Task> act = async () => { await useCase.Execute(request); };

            var exception = await Assert.ThrowsAsync<InvalidLoginException>(act);

            Assert.Equal(ResourceExceptionMessages.EMAIL_OR_PASSWORD_INVALID, exception.Message.ToString());
        }

        private static DoLoginUseCase CreateUseCase(RentCars.Domain.Entities.User? user = null)
        {
            var passwordEncripter = PasswordEncripterBuilder.Build();

            var userReadOnlyRepository = new UserReadOnlyRepositoryBuilder();

            if (user is not null)
                userReadOnlyRepository.GetByEmailAndPassword(user);

            return new DoLoginUseCase(userReadOnlyRepository.Build(), passwordEncripter);
        }
    }
}
