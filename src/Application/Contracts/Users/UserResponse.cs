
namespace Application.Contracts.Users
{
    public sealed record UserResponse(Guid Id, string  FirstName, string LastName, string Email)
    {

    }
}
