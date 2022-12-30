using Domain.Entities;

namespace Domain.Repositories
{
    public interface IJournalRepository : IBaseAsyncRepository<Journal>
    {
        
        Task<IEnumerable<Journal>> GetJournalByUserIdAndDateAsync(Guid userId, DateTime diaryDate, CancellationToken cancellationToken = default);

    }
}