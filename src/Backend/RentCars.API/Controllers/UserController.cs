using Microsoft.AspNetCore.Mvc;
using RentCars.Application.UseCases.User.Register;
using RentCars.Communication.Requests;
using RentCars.Communication.Responses;

namespace RentCars.API.Controllers
{
    public class UserController : RentCarsBaseController
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]

        public async Task<IActionResult> Register(
            [FromServices] IRegisterUserUseCase useCase,
            [FromBody] RequestRegisterUserJson request)
        {
            var result = await useCase.Execute(request);

            return Created(string.Empty, result);
        }
    }
}
