namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/assessments")]
    public class SelfAssessmentValueController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public SelfAssessmentValueController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        //[HttpGet(/{selfAssessmentValueId:Guid}, Name = "GetAssessment")]
        //[ProducesResponseType(typeof(SelfAssessmentValueResponse), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]

        //public async Task<IAsyncResult> GetSelfAssessmentValueById(Guid selfAssessmentValueId, CancellationToken cancellationToken)
        //{
        //    var query = new GetAssessmentByIdQuery(userId);

        //    var assessment = await _sender.Send(query, cancellationToken);
        //    return Ok(assessment);
        //}

        [HttpPost(Name = "AddSelfAssessmentValue")]
        [ProducesResponseType(typeof(SelfAssessmentValueResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateSelfAssessmentValue([FromBody] CreateSelfAssessmentValueRequest selfAssessmentValueRequest, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateSelfAssessmentCommand>(selfAssessmentValueRequest);

            var assessment = await _sender.Send(command, cancellationToken);

            return Created($"api/assessments/{assessment.AssessmentDate}", null);
        }

        [HttpPut("{selfAssessmentValueId:Guid}", Name = "UpdateSelfAssessmentValue")]
        [ProducesResponseType(typeof(SelfAssessmentValueResponse), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateSelfAssessmentValue([FromBody] UpdateSelfAssessmentValueRequest updateSelfAssessmentValueRequest, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateSelfAssessmentValueCommand>(updateSelfAssessmentValueRequest);

            await _sender.Send(command, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{selfAssessmentValueId:Guid}", Name = "DeleteSelfAssessmentValue")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSelfAssesmentValue(Guid selfAssessmentValueId, CancellationToken cancellationToken)
        {
            var command = new DeleteSelfAssessmentValueCommand(selfAssessmentValueId);

            await _sender.Send(command, cancellationToken);

            return NoContent();
        }
    }
}