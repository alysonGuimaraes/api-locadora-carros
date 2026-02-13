using FluentValidation;
using RentCars.Application.Validators;
using RentCars.Communication.Requests;
using RentCars.Exceptions;

namespace RentCars.Application.UseCases.User.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
    {
        public RegisterUserValidator()
        {
            // Validações padrão dos dados
            RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceExceptionMessages.NAME_USER_EMPTY);
            RuleFor(user => user.Lastname)
                .NotEmpty().WithMessage(ResourceExceptionMessages.LASTNAME_USER_EMPTY);
            RuleFor(user => user.Document).NotEmpty().WithMessage(ResourceExceptionMessages.DOCUMENT_USER_EMPTY);
            RuleFor(user => user.Document_Type).NotEmpty().WithMessage(ResourceExceptionMessages.DOCUMENT_TYPE_USER_EMPTY);
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage(ResourceExceptionMessages.EMAIL_USER_EMPTY)
                .EmailAddress().WithMessage(ResourceExceptionMessages.INVALID_EMAIL_ADDRESS);
            RuleFor(user => user.Password).NotEmpty().WithMessage(ResourceExceptionMessages.PASSWORD_USER_EMPTY);
            RuleFor(user => user.DDD).NotEmpty().WithMessage(ResourceExceptionMessages.DDD_USER_EMPTY);
            RuleFor(user => user.Phone_Number).NotEmpty().WithMessage(ResourceExceptionMessages.PHONE_USER_EMPTY);
            RuleFor(user => user.Birth_Date).NotEmpty().WithMessage(ResourceExceptionMessages.BIRTH_DATE_USER_EMPTY);
            RuleFor(user => user.Gender).NotEmpty().WithMessage(ResourceExceptionMessages.GENDER_EMPTY);


            RuleFor(user => user.Address)
                .NotEmpty().WithMessage(ResourceExceptionMessages.ADDRESS_EMPTY)
                .SetValidator(new AddressValidator());
        }
    }
}
