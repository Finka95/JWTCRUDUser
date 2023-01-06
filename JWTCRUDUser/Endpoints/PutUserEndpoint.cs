using JWTCRUDUser.Contracts.Responses;
using JWTCRUDUser.Mappers;
using JWTCRUDUser.Models;
using Microsoft.AspNetCore.Authorization;

namespace JWTCRUDUser.Endpoints
{
    [HttpPut("api/users/{userid}")]
    [Authorize(Roles = "Admin")]
    public class PutUserEndpoint : Endpoint<User, UserResponse, UserMapper>
    {
        private readonly UserContext _context;
        public ILogger<PutUserEndpoint>? _Logger {get;init;}

        public PutUserEndpoint(UserContext context)
        {
            _context = context;
        }
        public override async Task HandleAsync(User user, CancellationToken ct)
        {
            int userId = Route<int>("userId");
            _Logger!.LogDebug($"Change user (userId = {userId}) to db({user.ToString()})");
            User? userDB = _context!.users!.FirstOrDefault(u => u.Id == userId);
            if(userDB == null)
                await SendNotFoundAsync();
            else
            {
                userDB.Name = user.Name;
                userDB.Age = user.Age;
                _context.SaveChanges();
                var userResponses = Map.FromEntity(user!);
                await SendAsync(userResponses, cancellation: ct);
            }
        }
    }
}