namespace Application.Contracts.Journals
{
    public sealed record JournalResponse(string Titie, string Text, DateTime DiaryDate, Guid UserId)
    {
    }
}