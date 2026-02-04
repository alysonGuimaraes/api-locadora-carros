using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RentCars.Communication.Responses;
using RentCars.Exceptions;
using RentCars.Exceptions.ExceptionsBase;
using System.Net;

namespace RentCars.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context) 
        {
            if (context.Exception is RentCarsException)
            {
                HandleProjectExcpetion(context);
            }
            else
            {
                ThrowUnknownException(context);
            }
        }

        private void HandleProjectExcpetion(ExceptionContext context)
        {
            if (context.Exception is ErrorOnValidationException) 
            { 
                var exception = context.Exception as ErrorOnValidationException;

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception.ErrorsMessages));
            }
        }

        private void ThrowUnknownException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorJson(ResourceExceptionMessages.UNKNOWN_ERROR));
        }
    } 
}
