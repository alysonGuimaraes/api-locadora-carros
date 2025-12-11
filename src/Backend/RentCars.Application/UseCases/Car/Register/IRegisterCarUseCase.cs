using RentCars.Communication.Requests;
using RentCars.Communication.Responses;

namespace RentCars.Application.UseCases.Car.Register
{
    public interface IRegisterCarUseCase
    {
        public Task<ResponseRegisteredCarJson> Execute(RequestRegisterCarJson request);
    }
}
