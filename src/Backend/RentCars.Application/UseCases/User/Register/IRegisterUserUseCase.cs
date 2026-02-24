using RentCars.Communication.Requests;
using RentCars.Communication.Responses;

namespace RentCars.Application.UseCases.User.Register
{
    public interface IRegisterUserUseCase
    {
        public Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
    }
}
