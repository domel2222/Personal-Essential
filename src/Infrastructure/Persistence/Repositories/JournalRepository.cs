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
            return await _personalDbContext.Journals.FirstOrDefaultAsync(x => x.Id == journalId && x.InactivatedDate == null, cancellationToken);
        }

        public Task<Journal> GetJournalByUserIdAndDateAsync(Guid userid, DateTime diarydate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
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
    }
}