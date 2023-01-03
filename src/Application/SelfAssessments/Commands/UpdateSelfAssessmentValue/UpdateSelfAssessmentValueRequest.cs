using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SelfAssessments.Commands.UpdateSelfAssessmentValue
{
    public sealed record UpdateSelfAssessmentValueRequest(
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
     DateTime AssesmentDate,
     Guid SelfAssessmentValueId
        )
    {
    }
}
