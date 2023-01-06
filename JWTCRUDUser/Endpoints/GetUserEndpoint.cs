using JWTCRUDUser.Contracts.Requests;
using JWTCRUDUser.Contracts.Responses;
using JWTCRUDUser.Mappers;
using JWTCRUDUser.Models;
using Microsoft.AspNetCore.Authorization;

namespace JWTCRUDUser.Endpoints
{
    [HttpGet("api/users/{userId}")]
    [Authorize(Roles = "Admin")]
    public class GetUserEndpoint : Endpoint<UserIdRequest, UserResponse, UserMapper>
    {
        private readonly UserContext _context;
        public ILogger<GetUsersEndpoint>? _Logger {get;init;}

        public GetUserEndpoint(UserContext context)
        {
            _context = context;
        }
        public override async Task HandleAsync(UserIdRequest req, CancellationToken ct)
        {
            _Logger!.LogDebug($"Retrivering users with userID: {req.UserId}");
            var user = _context!.users!.FirstOrDefault(u => u.Id == req.UserId);

            if(user == null)
                await SendNotFoundAsync();
            else
            {
                var userResponses = Map.FromEntity(user!);
                await SendAsync(userResponses, cancellation: ct);
            }
        }
    }
}