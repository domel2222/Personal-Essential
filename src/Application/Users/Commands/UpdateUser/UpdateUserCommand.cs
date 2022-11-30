namespace Application.Users.Commands.UpdateUser
{
    public sealed record UpdateUserCommand(Guid userId, string FirstName, string LastName, string Email) : ICommand<Unit>;
}
