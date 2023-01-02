using Application.Contracts.Assessments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SelfAssessments.Commands
{
    public sealed record  CreateSelfAssessmentCommand(
     double DeepWorkResult,
     double AffirmationResult,
     double UsePhoneResult,
     double LearningResult,
     double StepsResult,
     double TrainingResult,
     double CaloriesResult,
     double EnglishTimeResult,
     double AudiobookReadingResult,
     double DailyResult,
    Guid UserId,
    Guid JournalId
        ) : ICommand<SelfAssessmentValueResponse>
    {
    }
}
