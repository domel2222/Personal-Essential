using Application.Journals.Command.UpdateJournal;
using Application.Journals.Queries.GetUserJournalsInSpecificDate;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using System.Threading;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/")]
    public class JournalController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public JournalController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet("journals/{UserId:Guid}/{DiaryDate:DateTime}")]
        [ProducesResponseType(typeof(List<JournalResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetJournalByUserIdInSpecificDate(Guid UserId, DateTime DiaryDate, CancellationToken cancellationToken)
        {
            var query = new GetJournalsInSpecificDateQuery(UserId, DiaryDate);

            var journals = await _sender.Send(query, cancellationToken);

            return Ok(journals);
        }

        [HttpPost("journal")]
        [ProducesResponseType(typeof(JournalResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateJournal([FromBody] CreateJournalRequest journalRequest, CancellationToken cancellationToken)
        {
            var command = journalRequest.Adapt<CreateJournalCommand>();

            var journal = await _sender.Send(command, cancellationToken);

            return Created($"api/journals/{journal.UserId}", null);
        }

        [HttpPut("journal/{journalId:Guid}")]
        [ProducesResponseType(typeof(JournalResponse), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateJournal([FromBody] UpdateJournalRequest updateJournalRequest, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateJournalCommand>(updateJournalRequest);

            await _sender.Send(command, cancellationToken);

            return NoContent();
        }

        //[HttpDelete]
    }
}