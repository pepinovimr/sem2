using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using vosplzen.sem2h1.Services;

namespace vosplzen.sem2h1.Filters
{
    public class IdentityFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {

        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var _authorizationService = (AuthorizationService?)context.HttpContext.RequestServices.GetService(typeof(AuthorizationService));

            if (_authorizationService is null)
            {
                context.Result = new ContentResult
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
                return;
            }

            context = _authorizationService.AuthorizeToken(context);
        }
    }
}
