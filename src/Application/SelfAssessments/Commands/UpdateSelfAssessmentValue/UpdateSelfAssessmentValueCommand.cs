namespace Application.SelfAssessments.Commands.UpdateSelfAssessmentValue
{
    public sealed record UpdateSelfAssessmentValueCommand(
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
        ) : ICommand<Result<Unit>>
    { }
}