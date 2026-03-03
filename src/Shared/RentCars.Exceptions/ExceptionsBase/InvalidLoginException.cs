namespace RentCars.Exceptions.ExceptionsBase
{
    public class InvalidLoginException : RentCarsException
    {
        public InvalidLoginException() : base(ResourceExceptionMessages.EMAIL_OR_PASSWORD_INVALID)
        {
        }
    }
}
