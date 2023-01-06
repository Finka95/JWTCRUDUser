using JWTCRUDUser.Contracts.Responses;
using JWTCRUDUser.Mappers;
using JWTCRUDUser.Models;
using Microsoft.AspNetCore.Authorization;

namespace JWTCRUDUser.Endpoints
{
    [HttpGet("api/users")]
    [Authorize(Roles = "Admin")]
    public class GetUsersEndpoint : EndpointWithoutRequest<UserResponses>
    {
        private readonly UserContext _context;
        private readonly UserMapper _mapper;
        public ILogger<GetUsersEndpoint>? _Logger {get;init;}

        public GetUsersEndpoint(UserMapper mapper, UserContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            _Logger!.LogDebug("Retrivering users");
            var users = _context!.users!.ToArray();

            var userResponses = new UserResponses
            {
                Users = users.Select(_mapper.FromEntity)
            };

            await SendAsync(userResponses, cancellation: ct);
        }
    }
}