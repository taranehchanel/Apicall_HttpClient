using CarService.Api;
using CarService.Persistence;
using CarService.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services
    .AddControllers();

builder.Services.AddScoped<CarRepository>();
builder.Services.AddDbContext<CarDbContext>
(options => options.UseSqlServer(connectionString:
    builder.Configuration.GetConnectionString(name: nameof(CarDbContext))));

builder.Services.AddHttpClient("services_client",
    configureClient: c => c.BaseAddress = new Uri("https://omidbnk.ir/gateway/services"));

builder.Services.AddHttpClient();



builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CustomAuthentication", policy =>
        policy.Requirements.Add(new CustomAuthenticationRequirement()));
});

builder.Services.AddSingleton<IAuthorizationHandler, CustomAuthenticationHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseMyMiddleware();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();