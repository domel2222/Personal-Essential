using Application.Contracts.MostWinsDuringTheDay;
using Application.MostWinsDuringTheDay.Command.CreateWin;
using Application.MostWinsDuringTheDay.Commands.CreateWin;
using Application.MostWinsDuringTheDay.Commands.DeleteWin;
using Application.MostWinsDuringTheDay.Commands.UpdateWin;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/mostWinDuringTheDay")]
    public class MostWinDuringTheDayController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public MostWinDuringTheDayController(IMapper mapper, ISender sender)
        {
            _mapper = mapper;
            _sender = sender;
        }

        [HttpPost(Name = "AddMostWinDuringheDay")]
        [ProducesResponseType(typeof(MostWinDuringTheDayResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateMostWin([FromBody] CreateMostWinDuringTheDayRequest mostWinRequest, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateMostWinDuringTheDayCommand>(mostWinRequest);

            var mostWin = await _sender.Send(command, cancellationToken);

            return Created($"api/MostWinDuringTheDay/{mostWin.MostWinId}", null);
        }

        [HttpPut("{mostWinId:Guid}", Name = "UpdateMostWinDuringTheDay")]
        [ProducesResponseType(typeof(MostWinDuringTheDayResponse), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMostWin([FromBody] UpdateMostWinDuringTheDayRequest mostWinRequest, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateSelfAssessmentValueCommand>(mostWinRequest);

            await _sender.Send(command, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{mostWinId:Guid}", Name = "DeleteMostWinDuringTheDay")]
        [ProducesResponseType(typeof(MostWinDuringTheDayResponse), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteMostWin(Guid mostWinId, CancellationToken cancellationToken)
        {
            var command = new DeleteMostWinDuringTheDayCommand(mostWinId);

            await _sender.Send(command, cancellationToken); 
            
            return NoContent();
        }
    }
}
