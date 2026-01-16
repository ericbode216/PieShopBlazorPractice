using Blazored.LocalStorage;
using PieShopHRM;
using PieShopHRM.Server.Components;
using PieShopHRM.Services;
using App = PieShopHRM.Server.Components.App;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

//added code beyond default
builder.Services.AddScoped<Microsoft.AspNetCore.Components.WebAssembly.Services.LazyAssemblyLoader>();

builder.Services.AddScoped<Microsoft.AspNetCore.Components.WebAssembly.Services.LazyAssemblyLoader>();
builder.Services.AddScoped<Microsoft.AspNetCore.Components.WebAssembly.Authentication.SignOutSessionStateManager>();


builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7039/");
});

builder.Services.AddHttpClient<ICountryDataService, CountryDataService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7039/");
});

builder.Services.AddHttpClient<IJobCategoryDataService, JobCategoryDataService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7039/");
});

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<ApplicationState>();

//added code till here

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
