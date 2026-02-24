using AutoMapper;
using RentCars.Application.Services.Cryptography;
using RentCars.Communication.Requests;
using RentCars.Communication.Responses;
using RentCars.Domain.Enums.User;
using RentCars.Domain.Extensions;
using RentCars.Domain.Repositories;
using RentCars.Domain.Repositories.User;
using RentCars.Exceptions;
using RentCars.Exceptions.ExceptionsBase;

namespace RentCars.Application.UseCases.User.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserReadOnlyRepository _readOnlyRepository;
        private readonly IUserWriteOnlyRepository _writeOnlyRepository;
        private readonly IUnitWork _workUnit;
        private readonly IMapper _mapper;
        private readonly PasswordEncripter _passwordEncripter;

        public RegisterUserUseCase(IUserReadOnlyRepository readOnlyRepository, IUserWriteOnlyRepository writeOnlyRepository, IUnitWork workUnit, IMapper mapper, PasswordEncripter passwordEncrypter)
        {
            _writeOnlyRepository = writeOnlyRepository;
            _readOnlyRepository = readOnlyRepository;
            _mapper = mapper;
            _workUnit = workUnit;
            _passwordEncripter = passwordEncrypter;
        }

        public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
        {
            await Validate(request);

            var user = _mapper.Map<Domain.Entities.User>(request);
            user.Password = _passwordEncripter.Encrypt(request.Password);
            await _writeOnlyRepository.Add(user);
            await _workUnit.Commit();

            return new ResponseRegisteredUserJson
            {
                Name = request.Name
            };
        }

        private async Task Validate(RequestRegisterUserJson request)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

            var userWithEmail = await _readOnlyRepository.ExistUserWithEmail(request.Email);
            if (userWithEmail)
            {
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceExceptionMessages.USER_EMAIL_ALREADY_REGISTERED));
            }

            var userWithPhone = await _readOnlyRepository.ExistUserWithPhone(request.Phone_Number, request.DDD);
            if (userWithPhone)
            {
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceExceptionMessages.USER_PHONE_NUMBER_ALREADY_REGISTERED));
            }

            var userWithDocument = await _readOnlyRepository.ExistUserWithDocument(Enum.Parse<EnumDocumentType>(request.Document_Type), request.Document);
            if (userWithDocument)
            {
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceExceptionMessages.USER_DOCUMENT_INVALID));
            }

            if (result.IsValid.IsFalse())
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }

        }
    }
}
