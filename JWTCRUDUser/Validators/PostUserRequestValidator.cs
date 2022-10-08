using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTCRUDUser.Models;
using FluentValidation;

namespace JWTCRUDUser.Validators
{
    public class PostUserRequestValidator : Validator<User>
    {
        public PostUserRequestValidator()
        {
            RuleFor(u => u.Name)
                .MinimumLength(2)
                .WithMessage("User name need to be more than 2 symbols")
                .MaximumLength(40)
                .WithMessage("User name need to be less than 40 symbols")
                .NotNull()
                .WithMessage("User name can't be null");
            
            RuleFor(u => u.Age)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Age need to be more than 1 years")
                .LessThanOrEqualTo(115)
                .WithMessage("Age can't be more than 115 years");
        }
    }
}