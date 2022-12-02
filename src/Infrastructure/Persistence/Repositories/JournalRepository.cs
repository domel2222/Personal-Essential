using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class JournalRepository : IJournalRepository
    {
        private readonly PersonalDbContext _personalDbContext;

        public JournalRepository(PersonalDbContext personalDbContext)
        {
            _personalDbContext = personalDbContext;
        }

        public Task<Journal> GetJournalByUserIdAndDate(Guid userid, DateTime diarydate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void Insert(Journal journal)
        {
            // if exist update ......
            _personalDbContext.Journals.Add(journal);      
        }

        public void Remove(Journal journal)
        {
            _personalDbContext.Journals.Remove(journal);
        }
    }
}
