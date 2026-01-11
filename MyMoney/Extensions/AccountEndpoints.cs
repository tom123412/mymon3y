using Asp.Versioning;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MyMoney.Extensions;

public static class AccountEndpoints
{
    public static IEndpointRouteBuilder MapAccountEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var apiVersionSet = endpoints
                .NewApiVersionSet()
                .HasApiVersion(new ApiVersion(1))
                .ReportApiVersions()
                .Build()
                ;

        var accountGroup = endpoints
            .MapGroup("/api/account")
            .WithApiVersionSet(apiVersionSet)
            ;

        accountGroup.MapGet("/login", async (HttpContext httpContext, string returnUrl = "/") =>
        {
            var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
                .WithRedirectUri(returnUrl)
                .Build();

            await httpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
        });

        accountGroup.MapPost("/logout", async (HttpContext httpContext) =>
        {
            var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
                .WithRedirectUri("/")
                .Build();

            await httpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        });

        return endpoints;
    }
}