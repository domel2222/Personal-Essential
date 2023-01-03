using Application.Journals.Command.DeleteJournal;

namespace Application.SelfAssessments.Commands.DeleteSelfAssessmentValue
{
    public class DeleteSelfAssessmentValueValidator : AbstractValidator<DeleteSelfAssessmentValueCommand>
    {
        public DeleteSelfAssessmentValueValidator() {

            RuleFor(x => x.SelfAssessmentValueId)
                                                            .NotEmpty()
                                                            .WithMessage($"{nameof(DeleteSelfAssessmentValueCommand.SelfAssessmentValueId)} {HelperValidator.NotNullOrEmpty}");
        }
    }
}
