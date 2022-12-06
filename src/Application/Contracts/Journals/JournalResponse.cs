namespace Application.Contracts.Journals
{
    public sealed record JournalResponse(string Titie, string Text, DateTime Diarydate, Guid Userid)
    //public sealed record JournalResponse(string Title, string Text, DateTime diaryDate, Guid userId)
    {
    }
}