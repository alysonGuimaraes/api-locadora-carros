using CommonTestUtilities.Requests.User;
using RentCars.Application.UseCases.User.Register;
using RentCars.Communication.Requests;
using RentCars.Exceptions;

namespace Validators.Test.User.Register
{
    public class RegisterUserValidatorTest
    {
        [Fact]
        public void Success()
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build();

            var result = validator.Validate(request);
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Error_User_FirstName_Empty()
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build();
            request.Name = string.Empty;

            var result = validator.Validate(request);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains(ResourceExceptionMessages.NAME_USER_EMPTY, result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void Error_User_LastName_Empty()
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build();
            request.Lastname = string.Empty;

            var result = validator.Validate(request);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains(ResourceExceptionMessages.LASTNAME_USER_EMPTY, result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void Error_User_DocumentType_Empty()
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build();
            request.Document_Type = string.Empty;

            var result = validator.Validate(request);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains(ResourceExceptionMessages.DOCUMENT_TYPE_USER_EMPTY, result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void Error_User_Document_Empty()
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build();
            request.Document = string.Empty;

            var result = validator.Validate(request);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains(ResourceExceptionMessages.DOCUMENT_USER_EMPTY, result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void Error_User_BirthDate_Empty()
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build();
            request.Birth_Date = null;

            var result = validator.Validate(request);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains(ResourceExceptionMessages.BIRTH_DATE_USER_EMPTY, result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void Error_User_Email_Empty()
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build();
            request.Email = String.Empty;

            var result = validator.Validate(request);
            Assert.False(result.IsValid);
            Assert.Contains(ResourceExceptionMessages.EMAIL_USER_EMPTY, result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void Error_User_DDD_Empty()
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build();
            request.DDD = String.Empty;

            var result = validator.Validate(request);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains(ResourceExceptionMessages.DDD_USER_EMPTY, result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void Error_User_PhoneNumber_Empty()
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build();
            request.Phone_Number = String.Empty;

            var result = validator.Validate(request);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains(ResourceExceptionMessages.PHONE_USER_EMPTY, result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void Error_User_Password_Empty()
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build();
            request.Password = String.Empty;

            var result = validator.Validate(request);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains(ResourceExceptionMessages.PASSWORD_USER_EMPTY, result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void Error_User_Gender_Empty()
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build();
            request.Gender = String.Empty;

            var result = validator.Validate(request);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains(ResourceExceptionMessages.GENDER_EMPTY, result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void Error_User_Address_Empty()
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build();
            request.Address = null;

            var result = validator.Validate(request);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains(ResourceExceptionMessages.ADDRESS_EMPTY, result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void Error_User_Address_City_Empty()
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build();
            request.Address!.City = string.Empty;

            var result = validator.Validate(request);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains(ResourceExceptionMessages.CITY_ADDRESS_EMPTY, result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void Error_User_Address_Neighborhood_Empty()
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build();
            request.Address!.Neighborhood = string.Empty;

            var result = validator.Validate(request);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains(ResourceExceptionMessages.NEIGHBORHOOD_ADDRESS_EMPTY, result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void Error_User_Address_State_Empty()
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build();
            request.Address!.State = string.Empty;

            var result = validator.Validate(request);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains(ResourceExceptionMessages.STATE_ADDRESS_EMPTY, result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void Error_User_Address_Street_Empty()
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build();
            request.Address!.Street = string.Empty;

            var result = validator.Validate(request);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains(ResourceExceptionMessages.STREET_ADDRESS_EMPTY, result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void Error_User_Address_Country_Empty()
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build();
            request.Address!.Country = string.Empty;

            var result = validator.Validate(request);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains(ResourceExceptionMessages.COUNTRY_ADDRESS_EMPTY, result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void Error_User_Address_ZipCode_Empty()
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build();
            request.Address!.Zip_Code = string.Empty;

            var result = validator.Validate(request);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains(ResourceExceptionMessages.ZIP_CODE_ADDRESS_EMPTY, result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void Error_User_Address_HouseNumber_Empty()
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build();
            request.Address!.House_Number = string.Empty;

            var result = validator.Validate(request);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            Assert.Contains(ResourceExceptionMessages.HOUSE_NUMBER_ADDRESS_EMPTY, result.Errors[0].ErrorMessage);
        }
        
    }
}
