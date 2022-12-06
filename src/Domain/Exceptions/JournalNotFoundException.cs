using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class JournalNotFoundException : NotFoundException
    {
        public JournalNotFoundException(Guid journalId) : base($"The journal with the identifier {journalId} was not found")
        {
        }
    }
}
