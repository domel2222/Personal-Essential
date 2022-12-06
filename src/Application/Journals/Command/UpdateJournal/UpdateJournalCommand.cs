namespace Application.Journals.Command.UpdateJournal
{
    public sealed record UpdateJournalCommand(Guid JournalId, string Title, string Text, DateTime DateTime) : ICommand<Unit>;

}
