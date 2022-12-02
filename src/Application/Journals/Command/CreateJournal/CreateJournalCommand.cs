namespace Application.Journals.Command.CreateJournal
{
    public sealed record CreateJournalCommand (string Title, string Text, DateTime diaryDate, Guid userId ) : ICommand<JournalResponse>
    {
    }
}
