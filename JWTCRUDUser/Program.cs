global using FastEndpoints;
using FastEndpoints.Security;
using JWTCRUDUser.Mappers;
using JWTCRUDUser.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

builder.Services.AddFastEndpoints();
builder.Services.AddAuthenticationJWTBearer(config.GetValue<string>("SecurityKeys:TokenSigningKey"));
builder.Services.AddDbContext<UserContext>(opt => opt.UseSqlite(config.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();

app.Run();