namespace Application.Users.Commands.DeleteUser
{
    public sealed class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.userId).NotEmpty().WithMessage("User Id should not be empty or null");
        }
    }
}