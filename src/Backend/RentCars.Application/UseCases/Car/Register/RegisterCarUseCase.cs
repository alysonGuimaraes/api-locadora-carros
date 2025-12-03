using RentCars.Communication.Requests;
using RentCars.Communication.Responses;
using RentCars.Exceptions.ExceptionsBase;

namespace RentCars.Application.UseCases.Car.Register
{
    public class RegisterCarUseCase
    {
        public ResponseRegisteredCarJson Execute(RequestRegisterCarJson request)
        {
            // Validar request
            Validate(request);

            // mapear a request em uma entidade

            // Salvar no banco de dados

            return new ResponseRegisteredCarJson
            {
                Model = request.Model,
            };
        }

        private void Validate(RequestRegisterCarJson request)
        {
            var validator = new RegisterCarValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }

        }
    }
}
