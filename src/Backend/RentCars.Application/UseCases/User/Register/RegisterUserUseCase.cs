using AutoMapper;
using RentCars.Communication.Requests;
using RentCars.Communication.Responses;
using RentCars.Domain.Extensions;
using RentCars.Domain.Repositories;
using RentCars.Domain.Repositories.User;
using RentCars.Exceptions.ExceptionsBase;

namespace RentCars.Application.UseCases.User.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserReadOnlyRepository _readOnlyRepository;
        private readonly IUserWriteOnlyRepository _writeOnlyRepository;
        private readonly IUnitWork _workUnit;
        private readonly IMapper _mapper;

        //public RegisterUserUseCase(IUserReadOnlyRepository readOnlyRepository, IUserWriteOnlyRepository writeOnlyRepository, IUnitWork workUnit, IMapper mapper) 
        //{
        //    _writeOnlyRepository = writeOnlyRepository;
        //    _readOnlyRepository = readOnlyRepository;
        //    _mapper = mapper;
        //    _workUnit = workUnit;
        //}

        public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
        {
            // Validar se a request é valida
            await Validate(request);

            // Salvar em banco de dados

            // Retornar a resposta
            return new ResponseRegisteredUserJson
            {
                Name = request.Name
            };
        }

        private async Task Validate(RequestRegisterUserJson request)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

            //var userWithEmail = await _readOnlyRepository.ExistUserWithEmail(request.Email);
            //if (userWithEmail)
            //{
            //    result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, "Email já existe"));
            //}

            //var userWithPhone = await _readOnlyRepository.ExistUserWithPhone(request.Phone_Number, request.DDD);
            //if (userWithPhone)
            //{
            //    result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, "Telefone já existe"));
            //}

            if (result.IsValid.IsFalse())
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }

        }
    }
}
