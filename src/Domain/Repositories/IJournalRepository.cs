using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IJournalRepository
    {
        Task<Journal> GetJournalById(Guid journalId, CancellationToken cancellationToken);
        Task<Journal> GetJournalByUserIdAndDate(Guid userId, DateTime diaryDate, CancellationToken cancellationToken = default);
        void Insert(Journal journal);
        void Remove(Journal journal);

    }
}
