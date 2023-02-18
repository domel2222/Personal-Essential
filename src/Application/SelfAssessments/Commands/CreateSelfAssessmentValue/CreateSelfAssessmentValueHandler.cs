namespace Application.SelfAssessments.Commands
{
    public sealed class CreateSelfAssessmentCommandHandler : ICommandHandler<CreateSelfAssessmentValueCommand, Result<SelfAssessmentValueResponse>>
    {
        private readonly ISelfAssessmentValueRepository _selfAssessmentValueRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICommandValidator<CreateSelfAssessmentValueCommand> _validator;

        public CreateSelfAssessmentCommandHandler(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            ISelfAssessmentValueRepository selfAssessmentValueRepository,
            ICommandValidator<CreateSelfAssessmentValueCommand> validator
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _selfAssessmentValueRepository = selfAssessmentValueRepository;
            _validator = validator;
        }

        public async Task<Result<SelfAssessmentValueResponse>> Handle(CreateSelfAssessmentValueCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return Utilities.CreateValidationErrorList<SelfAssessmentValueResponse>(validationResult);
            }

            var assessment = new SelfAssessmentValue
            {
                DeepWorkResult = request.DeepWorkResult,
                AffirmationResult = request.AffirmationResult,
                UsePhoneResult = request.UsePhoneResult,
                LearningResult = request.LearningResult,
                StepsResult = request.StepsResult,
                TrainingResult = request.TrainingResult,
                CaloriesResult = request.CaloriesResult,
                EnglishTimeResult = request.EnglishTimeResult,
                AudiobookReadingResult = request.AudiobookReadingResult,
                DailyResult = request.DailyResult,
                AssesmentDate = request.AssesmentDate,
                UserId = request.UserId,
                JournalId = request.JournalId
            };

            _selfAssessmentValueRepository.Insert(assessment);

            await _unitOfWork.SaveChangesAsync();

            return Result<SelfAssessmentValueResponse>.Succeed(_mapper.Map<SelfAssessmentValueResponse>(assessment));
            
        }
    }
}