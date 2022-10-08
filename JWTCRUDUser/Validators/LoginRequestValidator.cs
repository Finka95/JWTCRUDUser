using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTCRUDUser.Contracts.Requests;
using FluentValidation;

namespace JWTCRUDUser.Validators
{
    public class LoginRequestValidator : Validator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Username)
                .MinimumLength(2)
                .WithMessage("User name need to be more than 2 symbols")
                .MaximumLength(20)
                .WithMessage("User name need to be less than 20 symbols");
            
            RuleFor(x => x.Password)
                .MinimumLength(5)
                .WithMessage("Password need to be more than 5 symbols");
        }
    }
}