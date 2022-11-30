using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateUser
{
    public sealed record  UpdateUserRequest(string FirstName, string LastName, string email);
    
}
