
using Application.Common.Interfaces;
using Infrastructure.ExternalAPI.GoogleFIT;

namespace PersonalManagment.Api.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class FitnessApiController : ControllerBase
    {
        private readonly IFitnessGoogleApi _fitnessGoogleApi;
        public FitnessApiController(IFitnessGoogleApi fitnesttGoogleApi)
        {
            _fitnessGoogleApi = fitnesttGoogleApi;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("weight")]
        public async Task<ActionResult<IList<WeightDataPoint>>> GetWeight(DateTime start, DateTime end)
        {
            var list =  _fitnessGoogleApi.GetQueryWeightPerDay(start, end);

            //var vm = await Mediator.Send(new GetDirectorDetailQuery() { DirectorId = id });
            //return vm;
            return Ok(list);
        }


    }
}
