namespace RentCars.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException : RentCarsException
    {
        public IList<string> ErrorsMessages { get; set; }

        public ErrorOnValidationException(IList<string> errorMessages) : base(string.Empty)
        {
            ErrorsMessages = errorMessages;
        }
    }
}
