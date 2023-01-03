namespace Application.SelfAssessments.Commands
{
    public class CreateSelfAssessmentValueValidator : AbstractValidator<CreateSelfAssessmentCommand>
    {
        public CreateSelfAssessmentValueValidator()
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