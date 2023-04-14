using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using vosplzen.sem2h1.Data;

namespace vosplzen.sem2h1.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private ApplicationDbContext _context;

        public AuthorizationService(ApplicationDbContext context)
        {

            _context = context;
        }
        public ResourceExecutingContext AuthorizeToken(ResourceExecutingContext context)
        {
            var security_Id = context.HttpContext.Request.Headers.Where(x => x.Key == "Security-Identifier").FirstOrDefault();

            if (_context is null)
            {
                context.Result = new ContentResult
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
                return context;
            }

            var token = _context.SecurityTokens.FirstOrDefault(x => x.Token.Equals(security_Id.Value));

            if (token is null || token.ValidUntil <= DateTime.Now)
            {
                context.Result = new UnauthorizedResult();
            }

            return context;
        }
    }
}
