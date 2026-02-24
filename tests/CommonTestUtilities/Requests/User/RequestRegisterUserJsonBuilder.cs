
using Bogus;
using RentCars.Communication.Requests;
using System.Text;

namespace CommonTestUtilities.Requests.User
{
    public class RequestRegisterUserJsonBuilder
    {
        private static readonly Random _random = new Random();

        public static RequestRegisterUserJson Build()
        {
            return new Faker<RequestRegisterUserJson>()
                .RuleFor(user => user.Name, (f) => f.Name.FirstName())
                .RuleFor(user => user.Lastname, (f) => f.Name.LastName())
                .RuleFor(user => user.Email, (f) => f.Internet.Email())
                .RuleFor(user => user.Address, (f) => new RequestAddressJson
                {
                    Street = f.Address.StreetName(),
                    City = f.Address.City(),
                    State = f.Address.State(),
                    Zip_Code = f.Address.ZipCode("#########"),
                    Country = f.Address.Country(),
                    House_Number = f.Address.BuildingNumber(),
                    Neighborhood = "Test Neighborhood",
                })
                .RuleFor(user => user.Phone_Number, (f) => f.Phone.PhoneNumber("#########"))
                .RuleFor(user => user.DDD, "41")
                .RuleFor(user => user.Password, (f) => f.Internet.Password(10))
                .RuleFor(user => user.Document, (f) => GetCpf())
                .RuleFor(user => user.Document_Type, "CPF")
                .RuleFor(user => user.Birth_Date, (f) => f.Date.Past(30, DateTime.Now.AddYears(-18)))
                .RuleFor(user => user.Gender, "Male");
        }

        /// <summary>
        /// Gera um número de CPF válido.
        /// </summary>
        /// <returns>String contendo o CPF.</returns>
        private static string GetCpf()
        {
            int[] numeros = new int[11];
            for (int i = 0; i < 9; i++)
            {
                numeros[i] = _random.Next(0, 10);
            }

            numeros[9] = CalcularDigito(numeros, 9);
            numeros[10] = CalcularDigito(numeros, 10);

            StringBuilder sb = new StringBuilder();
            foreach (var numero in numeros)
            {
                sb.Append(numero);
            }

            string cpf = sb.ToString();

            return cpf;
        }

        private static int CalcularDigito(int[] numeros, int indiceMaximo)
        {
            int soma = 0;
            int peso = indiceMaximo + 1;

            for (int i = 0; i < indiceMaximo; i++)
            {
                soma += numeros[i] * peso--;
            }

            int resto = soma % 11;

            return resto < 2 ? 0 : 11 - resto;
        }
    }
}
