using MapsterMapper;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/journals")]
    public  class JournalController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;
        public JournalController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpPost("createJournal")]
        [ProducesResponseType(typeof(JournalResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateJournal([FromBody] CreateJournalRequest journalRequest, CancellationToken cancellationToken)
        {

            var command = journalRequest.Adapt<CreateJournalCommand>();

            var journal = await _sender.Send(command, cancellationToken);

            return Created($"api/journals/{journal.Userid}", null);
        }
    }
}
