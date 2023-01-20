namespace Application.Contracts.Journals
{
    public sealed record JournalResponse(string Title, string Text, DateTime DiaryDate, Guid UserId)
    {
    }
}