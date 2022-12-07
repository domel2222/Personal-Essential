namespace Application.Journals.Queries.GetUserJournalsInSpecificDate
{
    public sealed record GetJournalsInSpecificDateQuery(Guid UserId, DateTime DiaryDate) : IQuery<List<JournalResponse>>;
}
