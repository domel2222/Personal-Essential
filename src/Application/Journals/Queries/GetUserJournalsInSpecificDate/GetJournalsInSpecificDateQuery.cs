using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Journals.Queries.GetUserJournalsInSpecificDate
{
    public  sealed record GetJournalsInSpecificDateQuery(Guid UserId, DateTime DiaryDate) : IQuery<List<JournalResponse>>;
}
