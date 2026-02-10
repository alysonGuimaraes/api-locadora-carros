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
                HandleProjectException(context);
            }
            else
            {
                ThrowUnknownException(context);
            }
        }

        private static void HandleProjectException(ExceptionContext context)
        {
            if (context.Exception is ErrorOnValidationException exception) 
            { 
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception!.ErrorsMessages));
            }
        }

        private static void ThrowUnknownException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorJson(ResourceExceptionMessages.UNKNOWN_ERROR));
        }
    } 
}
