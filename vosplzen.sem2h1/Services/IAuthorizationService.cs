using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace vosplzen.sem2h1.Services
{
    public interface IAuthorizationService
    {
        public ResourceExecutingContext AuthorizeToken(ResourceExecutingContext context);
    }
}
