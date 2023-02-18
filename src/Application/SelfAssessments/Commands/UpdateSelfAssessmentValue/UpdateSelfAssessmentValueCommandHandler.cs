namespace Application.SelfAssessments.Commands.UpdateSelfAssessmentValue
{
    public class UpdateSelfAssessmentValueCommandHandler : ICommandHandler<UpdateSelfAssessmentValueCommand, Result<Unit>>
    {
        private readonly ISelfAssessmentValueRepository _selfAssessmentValueRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommandValidator<UpdateSelfAssessmentValueCommand> _validator;

        public UpdateSelfAssessmentValueCommandHandler(
                    ISelfAssessmentValueRepository selfAssessmentValueRepository, 
                    IUnitOfWork unitOfWork,
                    ICommandValidator<UpdateSelfAssessmentValueCommand> validator)
        {
            _selfAssessmentValueRepository = selfAssessmentValueRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Result<Unit>> Handle(UpdateSelfAssessmentValueCommand request, CancellationToken cancellationToken)
        {
            var validationReult = await _validator.ValidateAsync(request);

            if (!validationReult.IsValid) 
            {
                return Utilities.CreateValidationErrorList<Unit>(validationReult);
            }

            var assessment = await _selfAssessmentValueRepository.GetByIdAsync(request.SelfAssessmentValueId, cancellationToken);

            if (assessment is null)
            {
                throw new SelfAssessmentValueNotFountException(request.SelfAssessmentValueId);
            }

            assessment.DeepWorkResult = request.DeepWorkResult;
            assessment.AffirmationResult = request.AffirmationResult;
            assessment.UsePhoneResult = request.UsePhoneResult;
            assessment.LearningResult = request.LearningResult;
            assessment.StepsResult = request.StepsResult;
            assessment.TrainingResult = request.TrainingResult;
            assessment.CaloriesResult = request.CaloriesResult;
            assessment.EnglishTimeResult = request.EnglishTimeResult;
            assessment.AudiobookReadingResult = request.AudiobookReadingResult;
            assessment.DailyResult = request.DailyResult;
            assessment.AssesmentDate = request.AssesmentDate;

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Unit>.Succeed(Unit.Value);
        }
    }
}
