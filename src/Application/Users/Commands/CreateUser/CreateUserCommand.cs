﻿using Application.Abstractions.Messaging;
using Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    public record CreateUserCommand(string FirstName, string LastName, string Email) : ICommand<UserResponse>
    {

    }
}
