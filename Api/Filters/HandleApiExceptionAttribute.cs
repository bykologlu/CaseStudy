using Core.Utilities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace Api.Filters
{
    public class HandleApiExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {

            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

            IResponse response = new ErrorResponse();
            statusCode = HttpStatusCode.BadRequest;

            response.Message = context.Exception.Message;

            if (context.Exception.GetType() == typeof(NullReferenceException) ||
                context.Exception.GetType() == typeof(ArgumentException))
            {
                response.Message = "Parametre eksik veya hatalı.";
            }
            
            var request = context.ActionContext.Request;

            context.Response = request.CreateResponse(statusCode, response);

        }

    }
}