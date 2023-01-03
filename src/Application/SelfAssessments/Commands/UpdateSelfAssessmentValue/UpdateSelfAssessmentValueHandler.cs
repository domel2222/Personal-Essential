using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SelfAssessments.Commands.UpdateSelfAssessmentValue
{
    public class UpdateSelfAssessmentValueHandler : ICommandHandler<UpdateSelfAssessmentValueCommand, Unit>
    {
        private readonly ISelfAssessmentValueRepository _selfAssessmentValueRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSelfAssessmentValueHandler(ISelfAssessmentValueRepository selfAssessmentValueRepository, IUnitOfWork unitOfWork)
        {
            _selfAssessmentValueRepository = selfAssessmentValueRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateSelfAssessmentValueCommand request, CancellationToken cancellationToken)
        {
            var assessment = await _selfAssessmentValueRepository.GetByIdAsync(request.SelfAssessmentValueId, cancellationToken);

            if (assessment == null)
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

            return Unit.Value;
        }
    }
}
