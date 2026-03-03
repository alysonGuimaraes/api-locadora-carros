using Microsoft.AspNetCore.Mvc;
using RentCars.Application.UseCases.Car.Register;
using RentCars.Communication.Requests;
using RentCars.Communication.Responses;

namespace RentCars.API.Controllers
{
    public class CarController : RentCarsBaseController
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredCarJson), StatusCodes.Status201Created)]

        public async Task<IActionResult> Register(
            [FromServices]IRegisterCarUseCase useCase,
            [FromBody]RequestRegisterCarJson request)
        {
            var result = await useCase.Execute(request);

            return Created(string.Empty, result);
        }
    }
}
