using CommonTestUtilities.Requests;
using RentCars.Application.UseCases.Car.Register;
using RentCars.Exceptions;

namespace Validators.Test.Car.Register
{
    public class RegisterCarValidatorTest
    {
        [Fact]
        public void Success()
        {
            var validator = new RegisterCarValidator();

            var request = RequestRegisterCarJsonBuilder.Build();

            var result = validator.Validate(request);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void Error_CarModel_Empty()
        {
            var validator = new RegisterCarValidator();

            var request = RequestRegisterCarJsonBuilder.Build();
            request.Model = String.Empty;

            var result = validator.Validate(request);

            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains(ResourceExceptionMessages.MODEL_EMPTY, result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void Error_CarBrand_Empty()
        {
            var validator = new RegisterCarValidator();

            var request = RequestRegisterCarJsonBuilder.Build();
            request.Brand = String.Empty;

            var result = validator.Validate(request);

            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains(ResourceExceptionMessages.BRAND_EMPTY, result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void Error_CarLicensePlate_Empty()
        {
            var validator = new RegisterCarValidator();

            var request = RequestRegisterCarJsonBuilder.Build();
            request.License_Plate = String.Empty;

            var result = validator.Validate(request);

            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains(ResourceExceptionMessages.LICENSE_PLATE_EMPTY, result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void Error_CarLicensePlate_Length_Greater_Than_Seven()
        {
            var validator = new RegisterCarValidator();

            var request = RequestRegisterCarJsonBuilder.Build();
            request.License_Plate = "ABC123456";

            var result = validator.Validate(request);

            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains(ResourceExceptionMessages.LICENSE_PLATE_LENGTH_OUT_OF_RANGE, result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void Error_CarNumPassengers_GreaterThanZero()
        {
            var validator = new RegisterCarValidator();

            var request = RequestRegisterCarJsonBuilder.Build();
            request.Num_passengers = 0;

            var result = validator.Validate(request);

            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains(ResourceExceptionMessages.NUM_PASSENGER_NOT_GREATER_THAN_ZERO, result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void Error_CarSteeringType_Empty()
        {
            var validator = new RegisterCarValidator();

            var request = RequestRegisterCarJsonBuilder.Build();
            request.Steering_type = String.Empty;

            var result = validator.Validate(request);

            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains(ResourceExceptionMessages.STEERING_TYPE_INVALID, result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void Error_CarSteeringType_InvalidValue()
        {
            var validator = new RegisterCarValidator();

            var request = RequestRegisterCarJsonBuilder.Build();
            request.Steering_type = "TypeOutOfTheEnum";

            var result = validator.Validate(request);

            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains(ResourceExceptionMessages.STEERING_TYPE_INVALID, result.Errors[0].ErrorMessage);
        }

    }
}
