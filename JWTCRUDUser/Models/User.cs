using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTCRUDUser.Models
{
    public record class User
    {
        public int Id {get;set;}
        public string? Name {get;set;}
        public int Age {get;set;}
        public string Email => $"{Name}{Age}@gmail.com";
    }
}