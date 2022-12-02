using Application.Contracts.Journals;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/journals")]
    public  class JournalController : ControllerBase
    {
        private readonly ISender _sender;
        public JournalController(ISender sender)
        {
            _sender = sender;
        }


        [HttpPost("createJournal")]
        [ProducesResponseType(typeof(JournalResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserRequest userRequest, CancellationToken cancellationToken)
        {
            var command = userRequest.Adapt<CreateUserCommand>();

            var user = await _sender.Send(command, cancellationToken);

            return Created($"api/journals/{user.Id}", null);
        }
    }
}
