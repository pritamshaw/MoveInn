using MoveInn.BAL.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoveInn.UI.ModelValidators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.ID).NotNull();
            RuleFor(x => x.UserName).NotNull();
            RuleFor(x => x.UserName).Length(1, 50);
            RuleFor(x => x.Password).NotNull();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.EmailVerified).NotNull();
            RuleFor(x => x.IsActive).NotNull();
        }
    }
}