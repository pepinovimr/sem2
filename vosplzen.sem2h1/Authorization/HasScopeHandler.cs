using Microsoft.AspNetCore.Authorization;

namespace vosplzen.sem2h1.Authorization
{

    public class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasScopeRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "scope"))
                return Task.CompletedTask;

            var scopes = context.User.FindFirst(c => c.Type == "scope").Value.Split(' ');

            if (scopes.Any(s => s == requirement.Scope))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
