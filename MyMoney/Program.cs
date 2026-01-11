using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpOverrides;
using MyMoney.Components;
using MyMoney.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddAuth0WebAppAuthentication(options =>
    {
        options.Domain = builder.Configuration["Auth0:Domain"] ?? throw new InvalidOperationException("Auth0 Domain is not configured.");
        options.ClientId = builder.Configuration["Auth0:ClientId"] ?? throw new InvalidOperationException("Auth0 ClientId is not configured.");
    })
    ;

builder.Services.AddCascadingAuthenticationState();

builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents()
    ;

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedHost | ForwardedHeaders.XForwardedProto
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();
app
    .MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(MyMoney.Client._Imports).Assembly)
    ;

app.MapRazorPages();

app.MapAccountEndpoints();

app.Run();
