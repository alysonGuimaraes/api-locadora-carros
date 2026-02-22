using FluentValidation;
using RentCars.Communication.Requests;
using RentCars.Domain.Enums.Address;
using RentCars.Exceptions;

namespace RentCars.Application.Validators
{
    public class AddressValidator : AbstractValidator<RequestAddressJson>
    {
        public AddressValidator() 
        {
            RuleFor(address => address.Zip_Code)
                .NotEmpty().WithMessage(ResourceExceptionMessages.ZIP_CODE_ADDRESS_EMPTY);
            RuleFor(address => address.City).NotEmpty().WithMessage(ResourceExceptionMessages.CITY_ADDRESS_EMPTY);
            RuleFor(address => address.State)
                .NotEmpty().WithMessage(ResourceExceptionMessages.STATE_ADDRESS_EMPTY);
            RuleFor(address => address.State)
                .IsEnumName(typeof(EnumAddressState))
                    .When(address => string.Equals(address.Country, "Brasil", StringComparison.OrdinalIgnoreCase));
            RuleFor(address => address.Street).NotEmpty().WithMessage(ResourceExceptionMessages.STREET_ADDRESS_EMPTY);
            RuleFor(address => address.Country).NotEmpty().WithMessage(ResourceExceptionMessages.COUNTRY_ADDRESS_EMPTY);
            RuleFor(address => address.Neighborhood).NotEmpty().WithMessage(ResourceExceptionMessages.NEIGHBORHOOD_ADDRESS_EMPTY);
            RuleFor(address => address.House_Number).NotEmpty().WithMessage(ResourceExceptionMessages.HOUSE_NUMBER_ADDRESS_EMPTY);
        }
    }
}
