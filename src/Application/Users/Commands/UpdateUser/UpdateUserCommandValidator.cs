using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateUser
{
    public sealed class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.userId)
                                                    .NotEmpty();

            RuleFor(x => x.FirstName)
                                                    .NotEmpty()
                                                    .MaximumLength(100);

            RuleFor(x => x.LastName)
                                                    .NotEmpty()
                                                    .MaximumLength(100);

            RuleFor(x => x.Email)
                                                    .NotEmpty()
                                                    .WithMessage("Email address is required.")
                                                    .EmailAddress()
                                                    .WithMessage("A valid email address is required.");
        }
    }
}
