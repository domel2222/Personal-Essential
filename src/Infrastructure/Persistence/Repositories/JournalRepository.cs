using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class JournalRepository : IJournalRepository
    {
        private readonly PersonalDbContext _personalDbContext;

        public JournalRepository(PersonalDbContext personalDbContext)
        {
            _personalDbContext = personalDbContext;
        }

        public async Task<Journal> GetJournalByIdAsync(Guid journalId, CancellationToken cancellationToken)
        {
            return await _personalDbContext.Journals
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(x => x.Id == journalId && x.InactivatedDate == null, cancellationToken);
        }

        public void Insert(Journal? journal)
        {
            if (journal != null)
            {
                _personalDbContext.Journals.Add(journal);
            }
        }

        public void Remove(Journal? journal)
        {
            if (journal != null)
            {
                _personalDbContext.Journals.Remove(journal);
            }
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