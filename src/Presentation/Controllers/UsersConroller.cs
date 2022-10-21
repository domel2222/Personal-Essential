using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Users.Commands.CreateUser;
using MediatR;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Presentation.Controlers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersConroller : ControllerBase
    {
        private readonly ISender _sender;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="sender"></param>
        public UsersConroller(ISender sender)
        {
            _sender = sender;
        }



        [HttpPost]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status201Created)]
        public async Task<IAsyncResult> CreateUser([FromBody] CreateUserRequest userRequest, CancellationToken cancellationToken)
        {
            var command = userRequest.Adapt<CreateUserCommand>();

            var user = await _sender.Send(command, cancellationToken);

            return (IAsyncResult)Created("/1", user);
        }


    }
}
 