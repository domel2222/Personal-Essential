using Application.Contracts.Assessments;

namespace Application.SelfAssessments.Commands
{
    public sealed class CreateSelfAssessmentCommandHandler : ICommandHandler<CreateSelfAssessmentCommand, SelfAssessmentValueResponse>
    {
        private readonly ISelfAssessmentValueRepository _selfAssessmentValueRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSelfAssessmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ISelfAssessmentValueRepository selfAssessmentValueRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _selfAssessmentValueRepository = selfAssessmentValueRepository;
        }

        public async Task<SelfAssessmentValueResponse> Handle(CreateSelfAssessmentCommand request, CancellationToken cancellationToken)
        {
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

            return _mapper.Map<SelfAssessmentValueResponse>(assessment);
        }
    }
}