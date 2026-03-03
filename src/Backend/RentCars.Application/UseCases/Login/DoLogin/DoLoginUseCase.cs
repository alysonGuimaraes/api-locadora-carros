using RentCars.Application.Services.Cryptography;
using RentCars.Communication.Requests;
using RentCars.Communication.Responses;
using RentCars.Domain.Extensions;
using RentCars.Domain.Repositories.User;
using RentCars.Exceptions.ExceptionsBase;

namespace RentCars.Application.UseCases.Login.DoLogin
{
    public class DoLoginUseCase : IDoLoginUseCase
    {
        private readonly IUserReadOnlyRepository _userReadRepository;
        private readonly PasswordEncripter _passwordEncripter;

        public DoLoginUseCase(IUserReadOnlyRepository userReadRepository, PasswordEncripter passwordEncripter)
        {
            _userReadRepository = userReadRepository;
            _passwordEncripter = passwordEncripter;
        }

        public async Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request)
        {
            var validator = new DoLoginValidator();

            var result = validator.Validate(request);

            var encriptedPassword = _passwordEncripter.Encrypt(request.Password);
            var user = await _userReadRepository.GetByEmailAndPassword(request.Email, encriptedPassword) ?? throw new InvalidLoginException();

            if (result.IsValid.IsFalse())
                throw new InvalidLoginException();

            return new ResponseRegisteredUserJson
            {
                Name = user.Name
            };
        }
    }
}
