using Microsoft.AspNetCore.Mvc;
using RentCars.Application.UseCases.Login.DoLogin;
using RentCars.Communication.Requests;
using RentCars.Communication.Responses;

namespace RentCars.API.Controllers
{
    public class LoginController : RentCarsBaseController
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DoLogin(
                [FromServices]IDoLoginUseCase useCase,
                [FromBody]RequestLoginJson request
            )
        {
            var result = await useCase.Execute(request);

            return Ok(result);
        }
    }
}
