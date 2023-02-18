namespace Application.SelfAssessments.Commands
{
    public class CreateSelfAssessmentValueValidator : AbstractValidator<CreateSelfAssessmentValueCommand>, ISelfAssessmentCommandValidator<CreateSelfAssessmentValueCommand>
    {
        public CreateSelfAssessmentValueValidator()
        {
            RuleFor(x => x.UserId)
                                                    .NotEmpty()
                                                    .WithMessage($"{nameof(CreateSelfAssessmentValueCommand.UserId)} {HelperValidator.NotNullOrEmpty}");

            RuleFor(x => x.JournalId)
                                                    .NotEmpty()
                                                    .WithMessage($"{nameof(CreateSelfAssessmentValueCommand.JournalId)} {HelperValidator.NotNullOrEmpty}");
        }

        public Task<ValidationResult> ValidateAsync(CreateSelfAssessmentValueCommand command)
        {
            return Task.FromResult(Validate(command));
        }
    }
}