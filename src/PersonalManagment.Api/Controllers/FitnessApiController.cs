
namespace PersonalManagment.Api.Controllers
{
    [ApiController]
    [Route("[api/fitness")]
    public class FitnessApiController : ControllerBase
    {
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        [HttpGet("{weight}")]
        public async Task<IActionResult> GetWeight(int id)
        {
            //var vm = await Mediator.Send(new GetDirectorDetailQuery() { DirectorId = id });
            //return vm;
            return Ok(new { id });
        }
    }
}
