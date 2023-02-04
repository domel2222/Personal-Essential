namespace Domain.Repositories
{
    public interface IJournalRepository : IBaseAsyncRepository<Journal>
    {
        Task<IReadOnlyCollection<Journal>> GetAllJournalsByUserId(Guid userId, CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<Journal>> GetJournalByUserIdAndDateAsync(Guid userId, DateTime diaryDate, CancellationToken cancellationToken = default);
    }
}