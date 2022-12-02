﻿namespace Application.Users.Commands.UpdateUser
{
    public sealed record UpdateUserCommand(Guid UserId, string FirstName, string LastName, string Email) : ICommand<Unit>;
}
