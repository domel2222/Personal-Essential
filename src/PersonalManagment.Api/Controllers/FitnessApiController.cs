
using Application.Common.Interfaces;
using Infrastructure.ExternalAPI.GoogleFIT.DataPoint;
using Infrastructure.ExternalAPI.GoogleFIT.Interfaces;

namespace PersonalManagment.Api.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class FitnessApiController : ControllerBase
    {
        private readonly IWeightFitnessGoogleApi _weightFitnessGoogleApi;
        private readonly IActiveFitnessGoogleApi _activeFitnessGoogleApi;
        private readonly ISessionFitnessGoogleApi _sessionFitnessGoogleApi;

        public FitnessApiController(IWeightFitnessGoogleApi weightFitnesttGoogleApi,
                                    IActiveFitnessGoogleApi activeFitnessGoogleApi,
                                    ISessionFitnessGoogleApi sessionFitnessGoogleApi)
        {
            _weightFitnessGoogleApi = weightFitnesttGoogleApi ??
                throw new ArgumentNullException(nameof(weightFitnesttGoogleApi));

            _activeFitnessGoogleApi = activeFitnessGoogleApi ??
                 throw new ArgumentNullException(nameof(activeFitnessGoogleApi));

            _sessionFitnessGoogleApi = sessionFitnessGoogleApi ??
                throw new ArgumentNullException(nameof(sessionFitnessGoogleApi));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("weight")]
        public async Task<ActionResult<IList<WeightDataPoint>>> GetWeightPerDay(DateTime start, DateTime end)
        {
            var list =  _weightFitnessGoogleApi.GetQueryWeightPerDay(start, end);

            //var vm = await Mediator.Send(new GetDirectorDetailQuery() { DirectorId = id });
            //return vm;
            return Ok(list);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("steps")]
        public async Task<ActionResult<IList<StepsDataPoint>>> GetStepsPerDay(DateTime start, DateTime end)
        {
            var list = _activeFitnessGoogleApi.GetQueryStepsPerDay(start, end);

            return Ok(list);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("session")]
        public async Task<ActionResult<IList<StepsDataPoint>>> GetSessionPerDay(DateTime start, DateTime end, string activityType)
        {
            //var list = _sessionFitnessGoogleApi.GetSessionPerDay(start, end, activityType);
            var list = _sessionFitnessGoogleApi.GetSessionPerDay(start, end, activityType);

            return Ok(list);
        }


    }
}
