using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using QuitSmoking.BlazorWebApp.NamHH.Components;
using QuitSmoking.BlazorWebApp.NamHH.Components.Authentication;
using QuitSmoking.Repository.NamHH;
using QuitSmoking.Service.NamHH;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//builder.Services.AddServerSideBlazor()
//    .AddCircuitOptions(options =>
//    {
//        options.DetailedErrors = true;
//    });


//builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";

        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

        options.AccessDeniedPath = "/access-denied";
    });

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<IServiceProviders, ServiceProviders>();
builder.Services.AddScoped<ISystemUserAccountService, SystemUserAccountService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

//builder.Services.AddAuthorization();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

//app.UseAuthentication();
//app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
