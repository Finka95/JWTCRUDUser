using JWTCRUDUser.Contracts.Responses;
using JWTCRUDUser.Mappers;
using Microsoft.AspNetCore.Authorization;
using JWTCRUDUser.Models;

namespace JWTCRUDUser.Endpoints
{
    [HttpPost("api/users")]
    [Authorize(Roles = "Admin")]
    public class PostUserEndpoint : Endpoint<User, UserResponse, UserMapper>
    {
        private readonly UserContext _context;
        public ILogger<PostUserEndpoint>? _Logger {get;init;}

        public PostUserEndpoint(UserContext context)
        {
            _context = context;
        }
        public override async Task HandleAsync(User user, CancellationToken ct)
        {
            _Logger!.LogDebug($"Add user to db({user.ToString()})");
            _context!.Users!.Add(user);
            _context.SaveChanges();
            var userResponses = Map.FromEntity(user!);
            await SendAsync(userResponses, cancellation: ct);
        }
    }
}