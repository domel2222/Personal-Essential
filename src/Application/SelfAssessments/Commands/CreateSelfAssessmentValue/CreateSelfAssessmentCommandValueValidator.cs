namespace Application.SelfAssessments.Commands
{
    public class CreateSelfAssessmentCommandValueValidator : AbstractValidator<CreateSelfAssessmentCommand>
    {
        public CreateSelfAssessmentCommandValueValidator()
        {
            RuleFor(x => x.UserId)
                                                    .NotEmpty()
                                                    .WithMessage($"{nameof(CreateSelfAssessmentCommand.UserId)} {HelperValidator.NotNullOrEmpty}");

            RuleFor(x => x.JournalId)
                                                    .NotEmpty()
                                                    .WithMessage($"{nameof(CreateSelfAssessmentCommand.JournalId)} {HelperValidator.NotNullOrEmpty}");
        }
    }
}