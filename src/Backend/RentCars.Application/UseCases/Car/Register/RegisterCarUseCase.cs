using AutoMapper;
using RentCars.Communication.Requests;
using RentCars.Communication.Responses;
using RentCars.Domain.Extensions;
using RentCars.Domain.Repositories;
using RentCars.Domain.Repositories.Car;
using RentCars.Exceptions;
using RentCars.Exceptions.ExceptionsBase;

namespace RentCars.Application.UseCases.Car.Register
{
    public class RegisterCarUseCase : IRegisterCarUseCase
    {
        private readonly ICarReadOnlyRepository _readOnlyRepository;
        private readonly ICarWriteOnlyRepository _writeOnlyRepository;
        private readonly IUnitWork _workUnit;
        private readonly IMapper _mapper;

        public RegisterCarUseCase(ICarReadOnlyRepository readOnlyRepository, ICarWriteOnlyRepository writeOnlyRepository, IMapper mapper, IUnitWork workUnit)
        {
            _writeOnlyRepository = writeOnlyRepository;
            _readOnlyRepository = readOnlyRepository;
            _mapper = mapper;
            _workUnit = workUnit;
        }

        public async Task<ResponseRegisteredCarJson> Execute(RequestRegisterCarJson request)
        {
            // Validar request
            await Validate(request);

            // mapear a request em uma entidade
            var car = _mapper.Map<Domain.Entities.Car>(request);

            // Salvar no banco de dados
            await _writeOnlyRepository.Add(car);

            await _workUnit.Commit();

            return new ResponseRegisteredCarJson
            {
                Model = car.Model,
            };
        }

        private async Task Validate(RequestRegisterCarJson request)
        {
            var validator = new RegisterCarValidator();

            var result = validator.Validate(request);

            var plateExist = await _readOnlyRepository.ExistActiveCarWithPlate(request.License_Plate);
            if (plateExist)
            {
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceExceptionMessages.LICENSE_PLATE_ALREADY_REGISTERED));
            }

            if (result.IsValid.IsFalse())
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }

        }
    }
}
