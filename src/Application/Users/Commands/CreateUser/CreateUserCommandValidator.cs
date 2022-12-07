
using Application.Journals.Command.CreateJournal;

namespace Application.Users.Commands.CreateUser
{
    public sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator(IUserRepository userRepository)
        {
            RuleFor(x => x.FirstName)
                                                     .NotEmpty()
                                                     .WithMessage($"{nameof(CreateUserCommand.FirstName)} {HelperValidator.NotNullOrEmpty}")
                                                     .MaximumLength(100);

            RuleFor(x => x.LastName)
                                                    .NotEmpty()
                                                    .WithMessage($"{nameof(CreateUserCommand.LastName)} {HelperValidator.NotNullOrEmpty}")
                                                    .MaximumLength(100);

            RuleFor(x => x.Email)
                                                    .NotEmpty()
                                                    .WithMessage($"{nameof(CreateUserCommand.Email)} {HelperValidator.NotNullOrEmpty}")
                                                    .EmailAddress()
                                                    .WithMessage($"{nameof(CreateUserCommand.Email)} {HelperValidator.ValidEmail}");

            RuleFor(x => x.Email).Custom((email, context) =>
            {
                if (userRepository.CheckEmail(email))
                {
                    context.AddFailure($"{nameof(CreateUserCommand.Email)} ,{HelperValidator.ChooseAnotherEmail}.");
                }
}); 
        }
    }
}
