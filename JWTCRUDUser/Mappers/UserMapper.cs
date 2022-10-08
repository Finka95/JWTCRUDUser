using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTCRUDUser.Contracts.Requests;
using JWTCRUDUser.Contracts.Responses;
using JWTCRUDUser.Models;

namespace JWTCRUDUser.Mappers
{
    public class UserMapper : Mapper<UserIdRequest, UserResponse, User>
    {
        public override UserResponse FromEntity(User user)
        {
            return new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                Email = user.Email
            };
        }
    }
}