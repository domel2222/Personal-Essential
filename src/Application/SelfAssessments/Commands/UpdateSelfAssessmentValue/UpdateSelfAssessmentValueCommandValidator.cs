namespace Application.SelfAssessments.Commands.UpdateSelfAssessmentValue
{
    public class UpdateSelfAssessmentValueCommandValidator : AbstractValidator<UpdateSelfAssessmentValueCommand>, ISelfAssessmentCommandValidator<UpdateSelfAssessmentValueCommand>
    {
        public UpdateSelfAssessmentValueCommandValidator()
        {
            RuleFor(x => x.SelfAssessmentValueId)
                                                    .NotEmpty()
                                                    .WithMessage($"{nameof(UpdateSelfAssessmentValueCommand.SelfAssessmentValueId)} {HelperValidator.NotNullOrEmpty}");

            RuleFor(x => x.AssesmentDate).Custom((diaryDate, context) =>
            {
                if (!diaryDate.CompareDateToLocalTime())
                {
                    context.AddFailure($"{nameof(UpdateJournalCommand.Title)} :", $"{HelperValidator.CorrectDate}");
                }
            });
        }

        public Task<ValidationResult> ValidateAsync(UpdateSelfAssessmentValueCommand command)
        {
            return Task.FromResult(Validate(command));
        }
    }
}
