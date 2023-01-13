namespace Application.Journals.Command.CreateJournal
{
    public  sealed record CreateJournalCommand(string Title, string Text, DateTime Diarydate, Guid Userid) : ICommand<JournalResponse>
    {
    }
}
