using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using RentCars.Application.UseCases.Car.Register;
using RentCars.Exceptions;
using RentCars.Exceptions.ExceptionsBase;

namespace UseCases.Test.Car.Register
{
    public class RegisterCarUseCaseTest
    {
        [Fact]
        public async Task success()
        {
            var request = RequestRegisterCarJsonBuilder.Build();

            var useCase = CreateUseCase();

            var result = await useCase.Execute(request);

            Assert.Equal(request.Model, result.Model);
        }

        [Fact]
        public async Task Error_License_Plate_Already_Registered()
        {
            var request = RequestRegisterCarJsonBuilder.Build();

            var useCase = CreateUseCase(request.License_Plate);

            Func<Task> act = async () => await useCase.Execute(request);

            var exception = await Assert.ThrowsAsync<ErrorOnValidationException>(act);

            Assert.Single(exception.ErrorsMessages);
            Assert.Equal(ResourceExceptionMessages.LICENSE_PLATE_ALREADY_REGISTERED, exception.ErrorsMessages.First());
        }

        private RegisterCarUseCase CreateUseCase(string? plate = null)
        {
            var mapper = MapperBuilder.Build();
            var writeRepoitory = CarWriteOnlyRepositoryBuilder.Build();
            var unitWork = UnitWorkBuilder.Build();
            var readRepositoryBuilder = new CarReadOnlyRepositoryBuilder();

            if (!string.IsNullOrEmpty(plate)) 
            {
                readRepositoryBuilder.ExistActiveCarWithPlate(plate);
            }

            return new RegisterCarUseCase(readRepositoryBuilder.Build(), writeRepoitory, mapper, unitWork);
        }
    }
}
