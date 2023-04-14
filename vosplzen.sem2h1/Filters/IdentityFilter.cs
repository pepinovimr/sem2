using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using vosplzen.sem2h1.Services;

namespace vosplzen.sem2h1.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class IdentityFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {

        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            ///NEFUNGUJE!!!
            var _authorizationService = (AuthorizationService?)context.HttpContext.RequestServices.GetService(typeof(AuthorizationService));
            
            if (_authorizationService is null)
            {
                context.Result = new ContentResult
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
                return;
            }

            _authorizationService.AuthorizeToken(context);
        }
    }
}
