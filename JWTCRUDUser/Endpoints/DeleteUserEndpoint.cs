using JWTCRUDUser.Contracts.Requests;
using JWTCRUDUser.Contracts.Responses;
using JWTCRUDUser.Mappers;
using JWTCRUDUser.Models;
using Microsoft.AspNetCore.Authorization;

namespace JWTCRUDUser.Endpoints
{
    [HttpDelete("api/users/{userId}")]
    [Authorize(Roles = "Admin")]
    public class DeleteUserEndpoint : Endpoint<UserIdRequest, UserResponse, UserMapper>
    {
        private readonly UserContext _context;
        public ILogger<DeleteUserEndpoint>? _Logger {get;init;}
        
        public DeleteUserEndpoint(UserContext context)
        {
            _context = context;
        }

        public override async Task HandleAsync(UserIdRequest req, CancellationToken ct)
        {
            _Logger!.LogDebug($"Delete user from db ({req.UserId})");
            var user = _context!.Users!.FirstOrDefault(u => u.Id == req.UserId);

            if(user == null)
                await SendNotFoundAsync();
            else
            {
                _context!.Users!.Remove(user);
                _context.SaveChanges();
                var userResponses = Map.FromEntity(user!);
                await SendAsync(userResponses, cancellation: ct);
            }
        }
    }
}