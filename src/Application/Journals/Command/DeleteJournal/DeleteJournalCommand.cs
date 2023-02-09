namespace Application.Journals.Command.DeleteJournal
{
    public sealed record DeleteJournalCommand(Guid JournalId) : ICommand<Result<Unit>>;
}