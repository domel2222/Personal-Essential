namespace Domain.Exceptions
{
    public sealed class SelfAssessmentValueNotFountException : NotFoundException
    {
        public SelfAssessmentValueNotFountException(Guid guidId) : base($"The self assessment value with the identifier {guidId} was not found")
        {
        }
    }
}