using RentCars.Communication.Requests;
using RentCars.Communication.Responses;

namespace RentCars.Application.UseCases.Login.DoLogin
{
    public interface IDoLoginUseCase
    {
        public Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request);
    }
}
