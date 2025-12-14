using FluentValidation;
using RentCars.Communication.Requests;
using RentCars.Exceptions;

namespace RentCars.Application.UseCases.Car.Register
{
    internal class RegisterCarValidator : AbstractValidator<RequestRegisterCarJson>
    {
        public RegisterCarValidator() 
        {
            RuleFor(car => car.Model).NotEmpty().WithMessage(ResourceExceptionMessages.MODEL_EMPTY);

            RuleFor(car => car.Year).NotNull().WithMessage(ResourceExceptionMessages.YEAR_EMPTY);

            RuleFor(car => car.Brand).NotEmpty().WithMessage(ResourceExceptionMessages.BRAND_EMPTY);

            RuleFor(car => car.License_Plate).NotEmpty().WithMessage(ResourceExceptionMessages.LICENSE_PLATE_EMPTY);
        }
    }
}
