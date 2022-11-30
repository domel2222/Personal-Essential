using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Users
{
    public sealed record UserResponse(string FirstName, string LastName, string Email)
    {

    }
}
