using Bogus;
using RentCars.Communication.Requests;

namespace CommonTestUtilities.Requests
{
    public class RequestRegisterCarJsonBuilder
    {
        private const string Letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Numeros = "0123456789";

        public static RequestRegisterCarJson Build()
        {
            return new Faker<RequestRegisterCarJson>()
                .RuleFor(car => car.Model, (f) => f.Vehicle.Model())
                .RuleFor(car => car.Brand, (f) => f.Vehicle.Manufacturer())
                .RuleFor(car => car.Year, (f) => f.Random.Number(1908, DateTime.Now.Year))
                .RuleFor(car => car.License_Plate, GenerateMercosulLicensePlate())
                .RuleFor(car => car.Air_conditioning, (f) => f.Random.Bool())
                .RuleFor(car => car.ABS, (f) => f.Random.Bool())
                .RuleFor(car => car.Automatic_transmission, (f) => f.Random.Bool())
                .RuleFor(car => car.Steering_type, "Hydraulic")
                .RuleFor(car => car.Num_passengers, (f) => f.Random.Number(2, 8));
        }

        /// <summary>
        /// Generate a random license plate in Mercosul format (LLLNLNN).
        /// Exemplo: ABC1D23
        /// </summary>
        private static string GenerateMercosulLicensePlate()
        {
            var random = Random.Shared;

            char[] plate =
            [
                Letras[random.Next(Letras.Length)],
                Letras[random.Next(Letras.Length)],
                Letras[random.Next(Letras.Length)],
                Numeros[random.Next(Numeros.Length)],
                Letras[random.Next(Letras.Length)],
                Numeros[random.Next(Numeros.Length)],
                Numeros[random.Next(Numeros.Length)],
            ];
            return new string(plate);
        }
    }
}
