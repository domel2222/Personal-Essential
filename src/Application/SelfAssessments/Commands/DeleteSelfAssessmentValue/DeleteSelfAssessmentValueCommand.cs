namespace Application.SelfAssessments.Commands.DeleteSelfAssessmentValue
{
    public sealed record DeleteSelfAssessmentValueCommand(Guid SelfAssessmentValueId) : ICommand<Result<Unit>>
    {
    }
}
