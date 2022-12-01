
namespace Application.Users.Commands.DeleteUser
{
    public sealed record DeleteUserCommand(Guid userId) : ICommand<Unit>;

}
