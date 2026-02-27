using FluentValidation;
using RentCars.Communication.Requests;

namespace RentCars.Application.UseCases.Login.DoLogin
{
    public class DoLoginValidator : AbstractValidator<RequestLoginJson>
    {
        public DoLoginValidator() 
        {
            RuleFor(user => user.Email).NotEmpty();
            RuleFor(user => user.Password).NotEmpty();
        }
    }
}
