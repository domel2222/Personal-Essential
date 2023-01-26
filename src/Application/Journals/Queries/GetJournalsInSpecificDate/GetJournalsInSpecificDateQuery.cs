namespace Application.Journals.Queries.GetJournalsInSpecificDate
{
    public sealed record GetJournalsInSpecificDateQuery(Guid UserId, DateTime DiaryDate) : IQuery<List<JournalResponse>>;
}