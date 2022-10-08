using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastEndpoints.Security;
using JWTCRUDUser.Contracts.Requests;
using Microsoft.AspNetCore.Authorization;

namespace JWTCRUDUser.Endpoints
{
    [HttpPost("api/login")]
    [AllowAnonymous]
    public class UserLoginEndpoint : Endpoint<LoginRequest>
    {
        public ILogger<UserLoginEndpoint>? _Logger {get;init;}
        public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
        {
            _Logger!.LogDebug($"Create token for user \"{req.Username}\"");

            var jwtToken = JWTBearer.CreateToken(
                signingKey: "This is my super-puper securety token",
                expireAt: DateTime.UtcNow.AddDays(1),
                roles: new[] {"Admin"},
                claims: new[] {("UserName", req.Username)});

            await SendAsync(new
            {
                Username = req.Username,
                Token = jwtToken
            });
        }
    }
}