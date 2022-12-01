﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest userRequest, CancellationToken cancellationToken)
        {
            var command = userRequest.Adapt<CreateUserCommand>();

            var user = await _sender.Send(command, cancellationToken);

            return Created("/1", user);
        }


    }
}
 