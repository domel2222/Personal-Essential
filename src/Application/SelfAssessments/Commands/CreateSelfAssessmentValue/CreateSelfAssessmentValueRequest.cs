namespace Application.SelfAssessments.Commands
{
    public sealed record CreateSelfAssessmentValueRequest(
     double DeepWorkResult, 
     double AffirmationResult, 
     double UsePhoneResult ,
     double LearningResult ,
     double StepsResult ,
     double TrainingResult, 
     double CaloriesResult ,
     double EnglishTimeResult ,
     double AudiobookReadingResult, 
     double DailyResult,
     DateTime AssesmentDate,
     Guid UserId,
     Guid JournalId
        );
}
