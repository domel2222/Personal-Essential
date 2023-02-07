namespace Application.Journals.Command.CreateJournal
{
    public sealed record CreateJournalRequest(string Title, string Text, DateTime Diarydate, Guid Userid)
    {
    }
}