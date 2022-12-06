using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Journals.Command.CreateJournal
{
    public sealed record  CreateJournalRequest (string Title, string Text, DateTime Diarydate, Guid Userid)
    {
    }
}
