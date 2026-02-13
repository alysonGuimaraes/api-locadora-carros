using FluentValidation;
using RentCars.Communication.Requests;
using RentCars.Domain.Enums.Car;
using RentCars.Exceptions;

namespace RentCars.Application.UseCases.Car.Register
{
    public class RegisterCarValidator : AbstractValidator<RequestRegisterCarJson>
    {
        public RegisterCarValidator() 
        {
            RuleFor(car => car.Model).NotEmpty().WithMessage(ResourceExceptionMessages.MODEL_EMPTY);

            RuleFor(car => car.Brand).NotEmpty().WithMessage(ResourceExceptionMessages.BRAND_EMPTY);

            RuleFor(car => car.Year).NotNull().WithMessage(ResourceExceptionMessages.YEAR_EMPTY)
                .GreaterThanOrEqualTo(1908).WithMessage(ResourceExceptionMessages.YEAR_FIRST_FORD);

            RuleFor(car => car.License_Plate).NotEmpty().WithMessage(ResourceExceptionMessages.LICENSE_PLATE_EMPTY)
                .Length(0,7).WithMessage(ResourceExceptionMessages.LICENSE_PLATE_LENGTH_OUT_OF_RANGE);

            RuleFor(car => car.Num_passengers).GreaterThan(0).WithMessage(ResourceExceptionMessages.NUM_PASSENGER_NOT_GREATER_THAN_ZERO);

            RuleFor(car => car.Steering_type).Must(s => Enum.TryParse<EnumCarSteeringType>(s, out _)).WithMessage(ResourceExceptionMessages.STEERING_TYPE_INVALID);
        }
    }
}
