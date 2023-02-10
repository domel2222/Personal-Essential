namespace Application.Journals.Command.DeleteJournal
{
    public class DeleteJournalCommandValidator : AbstractValidator<DeleteJournalCommand>, IJournalCommandValidator<DeleteJournalCommand>
    {
        public DeleteJournalCommandValidator()
        {
            RuleFor(x => x.JournalId)
                                                        .NotEmpty()
                                                        .WithMessage($"{nameof(DeleteJournalCommand.JournalId)} {HelperValidator.NotNullOrEmpty}");
        }

        public Task<ValidationResult> ValidateAsync(DeleteJournalCommand command)
        {
            return Task.FromResult(Validate(command));
        }
    }
}