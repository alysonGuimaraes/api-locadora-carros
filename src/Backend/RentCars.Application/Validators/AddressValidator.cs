using FluentValidation;
using RentCars.Communication.Requests;
using RentCars.Domain.Enums.Address;
using RentCars.Exceptions;
using System.Net;

namespace RentCars.Application.Validators
{
    public class AddressValidator : AbstractValidator<RequestAddressJson>
    {
        public AddressValidator() 
        {
            RuleFor(address => address.Zip_Code)
                .NotNull().WithMessage(ResourceExceptionMessages.ZIP_CODE_ADDRESS_EMPTY);
            RuleFor(address => address.City).NotNull().WithMessage(ResourceExceptionMessages.CITY_ADDRESS_EMPTY);
            RuleFor(address => address.State)
                .NotNull().WithMessage(ResourceExceptionMessages.STATE_ADDRESS_EMPTY)
                .IsEnumName(typeof(EnumAddressState))
                    .When(address => string.Equals(address.Country, "Brasil", StringComparison.OrdinalIgnoreCase));
            RuleFor(address => address.Street).NotNull().WithMessage(ResourceExceptionMessages.STREET_ADDRESS_EMPTY);
            RuleFor(address => address.Country).NotNull().WithMessage(ResourceExceptionMessages.COUNTRY_ADDRESS_EMPTY);
            RuleFor(address => address.Neighborhood).NotNull().WithMessage(ResourceExceptionMessages.NEIGHBORHOOD_ADDRESS_EMPTY);
        }
    }
}
