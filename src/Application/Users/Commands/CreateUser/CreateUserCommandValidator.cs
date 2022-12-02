
namespace Application.Users.Commands.CreateUser
{
    public sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator(IUserRepository userRepository)
        {
            RuleFor(x => x.FirstName)
                                                     .NotEmpty()
                                                     .WithMessage("First should not be null or empty!")
                                                     .MaximumLength(100);

            RuleFor(x => x.LastName)
                                                    .NotEmpty()
                                                    .WithMessage("LastName should not be null or empty!")
                                                    .MaximumLength(100);

            RuleFor(x => x.Email)
                                                    .NotEmpty()
                                                        .WithMessage("Email address is required.")
                                                    .EmailAddress()
                                                        .WithMessage("A valid email address is required.");

            RuleFor(x => x.Email).Custom((email, context) =>
            {
                if (userRepository.CheckEmail(email))
                {
                    context.AddFailure("Email :", "Please insert another email this is taken");
                }
}); 
        }
    }
}
