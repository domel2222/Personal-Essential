namespace Presentation.Controlers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly ISender _sender;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="sender"></param>
        public UserController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(List<UserResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
        {
            var query = new GetUsersQuery();

            var users = await _sender.Send(query, cancellationToken);

            return Ok(users);
        }

        [HttpGet("getOne/{userId:Guid}")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserById(Guid userId, CancellationToken cancellationToken)
        {
            var query = new GetUserByIdQuery(userId);

            var user = await _sender.Send(query, cancellationToken);

            return Ok(user);
        }

        [HttpPost("createUser")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest userRequest, CancellationToken cancellationToken)
        {
            var command = userRequest.Adapt<CreateUserCommand>();

            var user = await _sender.Send(command, cancellationToken);

            return CreatedAtAction(nameof(GetUserById), new { userId = user.Id }, user);
        }

        [HttpPut("{userId:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] UpdateUserRequest updateUserRequest, CancellationToken cancellationToken)
        {
            var command = updateUserRequest.Adapt<UpdateUserCommand>() with
            {
                UserId = userId
            };

            await _sender.Send(command, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{userId:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(Guid userId, CancellationToken cancellationToken)
        {
            var command = new DeleteUserCommand(userId);

            await _sender.Send(command, cancellationToken);

            return NoContent();
        }
    }
}