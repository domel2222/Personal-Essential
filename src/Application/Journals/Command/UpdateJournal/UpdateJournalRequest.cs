namespace Application.Journals.Command.UpdateJournal
{
    public sealed record UpdateJournalRequest(Guid JournalId, string Title, string Text, DateTime DiaryDate)
    {
    }
}
