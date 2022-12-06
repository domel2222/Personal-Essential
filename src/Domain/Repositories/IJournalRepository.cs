using Domain.Entities;

namespace Domain.Repositories
{
    public interface IJournalRepository
    {
        Task<Journal> GetJournalByIdAsync(Guid journalId, CancellationToken cancellationToken);

        Task<Journal> GetJournalByUserIdAndDateAsync(Guid userId, DateTime diaryDate, CancellationToken cancellationToken = default);

        void Insert(Journal journal);

        void Remove(Journal journal);
    }
}