global using FastEndpoints;
using FastEndpoints.Security;
using JWTCRUDUser.Models;
using Microsoft.EntityFrameworkCore;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();
builder.Services.AddAuthenticationJWTBearer(config.GetValue<string>("SecurityKeys:TokenSigningKey"));
builder.Services.AddDbContext<UserContext>(opt => opt.UseNpgsql(config.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());

app.Run();