
using Application.Contracts.Assessments;

namespace Application.Users.Commands.CreateUser
{
    public sealed record CreateUserCommand(string FirstName, string LastName, string Email) : ICommand<UserResponse>
    {

    }
}
