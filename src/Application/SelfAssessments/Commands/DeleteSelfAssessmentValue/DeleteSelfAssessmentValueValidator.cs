namespace Application.SelfAssessments.Commands.DeleteSelfAssessmentValue
{
    public class DeleteSelfAssessmentValueValidator : AbstractValidator<DeleteSelfAssessmentValueCommand>, ISelfAssessmentCommandValidator<DeleteSelfAssessmentValueCommand>
    {
        public DeleteSelfAssessmentValueValidator() {

            RuleFor(x => x.SelfAssessmentValueId)
                                                            .NotEmpty()
                                                            .WithMessage($"{nameof(DeleteSelfAssessmentValueCommand.SelfAssessmentValueId)} {HelperValidator.NotNullOrEmpty}");
        }

        public Task<ValidationResult> ValidateAsync(DeleteSelfAssessmentValueCommand command)
        {
            return Task.FromResult(Validate(command));
        }
    }
}
