using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace CarService.Api;

public class CustomAuthenticationRequirement:IAuthorizationRequirement
{
    
}

public class CustomAuthenticationHandler : AuthorizationHandler<CustomAuthenticationRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomAuthenticationRequirement requirement)
    {
        //your previous codes to check the user
        if (context.Resource is HttpContext authorizationFilterContext)
        {
            if (authorizationFilterContext.Request.Headers.ContainsKey("Authorization"))
            {
                var authToken = authorizationFilterContext.Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
                var decodedAuthToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
                var arrUsernameandPassword = decodedAuthToken.Split(':');
                if (IsAuthorizedUser(arrUsernameandPassword[0], arrUsernameandPassword[1]))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, arrUsernameandPassword[0])
                    };

                    var identity = new ClaimsIdentity(claims, "custom");
                    var principal = new ClaimsPrincipal(identity);
                    authorizationFilterContext.User = principal;

                    context.Succeed(requirement);
                }
            }
        }

        return Task.CompletedTask;
    }

    private bool IsAuthorizedUser(string username, string password)
    {
        return username == "test" && password == "pass";
    }
}