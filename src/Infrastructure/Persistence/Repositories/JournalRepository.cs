using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class JournalRepository : BaseRepository<Journal>, IJournalRepository
    {
        public JournalRepository(PersonalDbContext personalDbContext) : base(personalDbContext)
        {
        }

        public async Task<IEnumerable<Journal>> GetJournalByUserIdAndDateAsync(Guid userId, DateTime diaryDate, CancellationToken cancellationToken)
        {
            return await _personalDbContext.Journals
                                                .AsNoTracking()
                                                .Where(x => x.UserId == userId
                                                && x.DiaryDate >= diaryDate && x.DiaryDate < diaryDate.AddDays(1)
                                                && x.InactivatedDate == null)
                                                .ToListAsync(cancellationToken);
        }
    }
}