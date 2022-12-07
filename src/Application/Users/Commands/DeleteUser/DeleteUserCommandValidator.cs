using Application.Users.Commands.UpdateUser;

namespace Application.Users.Commands.DeleteUser
{
    public sealed class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty()
                                                          .WithMessage($"{nameof(DeleteUserCommand.UserId)} {HelperValidator.NotNullOrEmpty}");
        }
    }
}