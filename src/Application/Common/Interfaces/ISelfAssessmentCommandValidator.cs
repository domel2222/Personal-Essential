namespace Application.Common.Interfaces
{
    internal interface ISelfAssessmentCommandValidator<T> : ICommandValidator<T> , IValidator<T>
    {
    }
}
