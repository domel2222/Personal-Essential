using Application.Users.Commands.CreateUser;

namespace Application.Users.Commands.UpdateUser
{
    public sealed class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.UserId)
                                                    .NotEmpty()
                                                    .WithMessage($"{nameof(UpdateUserCommand.UserId)} {HelperValidator.NotNullOrEmpty}");


            RuleFor(x => x.FirstName)
                                                    .NotEmpty()
                                                    .WithMessage($"{nameof(UpdateUserCommand.FirstName)} {HelperValidator.NotNullOrEmpty}")
                                                    .MaximumLength(100);

            RuleFor(x => x.LastName)
                                                    .NotEmpty()
                                                    .WithMessage($"{nameof(UpdateUserCommand.FirstName)} {HelperValidator.NotNullOrEmpty}")
                                                    .MaximumLength(100);

            RuleFor(x => x.Email)
                                                    .NotEmpty()
                                                    .WithMessage($"{nameof(UpdateUserCommand.Email)} {HelperValidator.NotNullOrEmpty}")
                                                    .EmailAddress()
                                                    .WithMessage($"{nameof(UpdateUserCommand.Email)} {HelperValidator.ValidEmail}");
        }
    }
}