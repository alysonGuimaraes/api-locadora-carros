using Bogus;
using RentCars.Communication.Requests;

namespace CommonTestUtilities.Requests.Login
{
    public class RequestLoginJsonBuilder
    {
        public static RequestLoginJson Build()
        {
            return new Faker<RequestLoginJson>()
                .RuleFor(login => login.Email, f => f.Internet.Email())
                .RuleFor(login => login.Password, f => f.Internet.Password());
        }
    }
}
