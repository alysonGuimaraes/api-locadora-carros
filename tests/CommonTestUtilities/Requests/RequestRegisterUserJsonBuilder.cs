using Bogus;
using RentCars.Communication.Requests;

namespace CommonTestUtilities.Requests
{
    public class RequestRegisterCarJsonBuilder
    {

        public static RequestRegisterCarJson Build()
        {
            return new Faker<RequestRegisterCarJson>()
                .RuleFor(car => car.Model, (f) => f.Vehicle.Model())
                .RuleFor(car => car.Brand, (f) => f.Vehicle.Manufacturer())
                .RuleFor(car => car.Year, (f) => f.Random.Number(1886, DateTime.Now.Year))
                .RuleFor(car => car.License_Plate, "ABC1234")
                .RuleFor(car => car.Air_conditioning, (f) => f.Random.Bool())
                .RuleFor(car => car.ABS, (f) => f.Random.Bool())
                .RuleFor(car => car.Automatic_transmission, (f) => f.Random.Bool())
                .RuleFor(car => car.Steering_type, "Hydraulic")
                .RuleFor(car => car.Num_passengers, (f) => f.Random.Number(2, 8));
        }
    }
}
