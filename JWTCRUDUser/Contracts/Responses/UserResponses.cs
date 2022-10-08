using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTCRUDUser.Contracts.Responses
{
    public class UserResponses
    {
        public IEnumerable<UserResponse>? Users {get;set;}
    }
}