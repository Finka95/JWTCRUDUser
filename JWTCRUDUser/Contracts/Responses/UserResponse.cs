using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTCRUDUser.Contracts.Responses
{
    public class UserResponse
    {
        public int Id {get;set;}
        public string? Name {get;set;}
        public int Age {get;set;}
        public string? Email {get;set;}
    }
}