using Microsoft.AspNetCore.Mvc;
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
            return Created();
        }
    }
}
