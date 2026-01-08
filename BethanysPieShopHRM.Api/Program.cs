using BethanysPieShopHRM.Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
/*
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/pieshop.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

//builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
builder.Logging.AddSerilog();
*/

// Add services to the container.

/*
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:DefaultConnection"]);
});
*/
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(
        builder.Configuration["ConnectionStrings:LocalMySQLDBConnectionString"],
        ServerVersion.AutoDetect(
            builder.Configuration["ConnectionStrings:LocalMySQLDBConnectionString"]
        )
    );
});

builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IJobCategoryRepository, JobCategoryRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "Open",
        builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
    );
});

builder.Services.AddControllers();

builder
    .Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.Authority = $"https://{builder.Configuration["Auth0:Domain"]}";
        options.TokenValidationParameters = 
            new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidAudience = builder.Configuration["Auth0:Audience"],
                ValidIssuer = $"https://{builder.Configuration["Auth0:Domain"]}",
            };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*
builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri("http://localhost:7039/api/employee")
    });
*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
}

app.UseBlazorFrameworkFiles();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.UseCors("Open");

app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();
