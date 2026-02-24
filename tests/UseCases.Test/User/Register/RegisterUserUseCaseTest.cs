
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Repositories.User;
using CommonTestUtilities.Requests.User;
using RentCars.Application.Services.Cryptography;
using RentCars.Application.UseCases.User.Register;
using RentCars.Domain.Enums.User;
using RentCars.Exceptions;
using RentCars.Exceptions.ExceptionsBase;

namespace UseCases.Test.User.Register
{
    public class RegisterUserUseCaseTest
    {
        [Fact]
        public async Task Success()
        {
            var request = RequestRegisterUserJsonBuilder.Build();

            var useCase = CreateUseCase();

            var result = await useCase.Execute(request);

            Assert.Equal(request.Name, result.Name);
        }

        [Fact]
        public async Task Error_User_Email_Already_Registered()
        {
            var request = RequestRegisterUserJsonBuilder.Build();

            var useCase = CreateUseCase(email:request.Email);

            Func<Task> act = async () => await useCase.Execute(request);

            var exception = await Assert.ThrowsAsync<ErrorOnValidationException>(act);

            Assert.Single(exception.ErrorsMessages);
            Assert.Equal(ResourceExceptionMessages.USER_EMAIL_ALREADY_REGISTERED, exception.ErrorsMessages.First());
        }

        [Fact]
        public async Task Error_User_Phone_Number_Already_Registered()
        {
            var request = RequestRegisterUserJsonBuilder.Build();

            var useCase = CreateUseCase(phone: request.Phone_Number);

            Func<Task> act = async () => await useCase.Execute(request);

            var exception = await Assert.ThrowsAsync<ErrorOnValidationException>(act);

            Assert.Single(exception.ErrorsMessages);
            Assert.Equal(ResourceExceptionMessages.USER_PHONE_NUMBER_ALREADY_REGISTERED, exception.ErrorsMessages.First());
        }

        [Fact]
        public async Task Error_User_Document_Already_Registered()
        {
            var request = RequestRegisterUserJsonBuilder.Build();

            var useCase = CreateUseCase(document: request.Document);

            Func<Task> act = async () => await useCase.Execute(request);

            var exception = await Assert.ThrowsAsync<ErrorOnValidationException>(act);

            Assert.Single(exception.ErrorsMessages);
            Assert.Equal(ResourceExceptionMessages.USER_DOCUMENT_INVALID, exception.ErrorsMessages.First());
        }

        private static RegisterUserUseCase CreateUseCase(string? email = null, string? phone = null, string? document = null)
        {
            var mapper = MapperBuilder.Build();
            var writeRepoitory = UserWriteOnlyRepositoryBuilder.Build();
            var unitWork = UnitWorkBuilder.Build();
            var readRepositoryBuilder = new UserReadOnlyRepositoryBuilder();
            var passwordEncripter = new PasswordEncripter("Test");

            if (!string.IsNullOrEmpty(email))
            {
                readRepositoryBuilder.ExistUserWithEmail(email);
            }

            if (!string.IsNullOrEmpty(phone))
            {
                readRepositoryBuilder.ExistUserWithPhone(phone, "41");
            }

            if (!string.IsNullOrEmpty(document))
            {
                readRepositoryBuilder.ExistUserWithDocument(EnumDocumentType.CPF, document);
            }

            return new RegisterUserUseCase(readRepositoryBuilder.Build(), writeRepoitory, unitWork, mapper, passwordEncripter);
        }
    }
}
