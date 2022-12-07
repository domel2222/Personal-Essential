using Application.Journals.Command.CreateJournal;

namespace Application.Journals.Command.DeleteJournal
{
    public class DeleteJournalCommandValidator : AbstractValidator<DeleteJournalCommand>
    {
        public DeleteJournalCommandValidator()
        {
            RuleFor(x => x.JournalId)
                                                        .NotEmpty()
                                                        .WithMessage($"{nameof(DeleteJournalCommand.JournalId)} {HelperValidator.NotNullOrEmpty}");
        }
    }
}