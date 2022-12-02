namespace Application.Contracts.Journals
{
    public sealed record JournalResponse(Guid id, string Titie, DateTime diaryDate, Guid userId)
    {
    }
}