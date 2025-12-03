using Microsoft.AspNetCore.Mvc;
using RentCars.Application.UseCases.Car.Register;
using RentCars.Communication.Requests;
using RentCars.Communication.Responses;

namespace RentCars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredCarJson), StatusCodes.Status201Created)]
        public IActionResult Register(RequestRegisterCarJson request)
        {
            var useCase = new RegisterCarUseCase();

            var result = useCase.Execute(request);

            return Created(string.Empty, result);
        }
    }
}
