using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MostWinsDuringTheDay.Commands.CreateWin
{
    public sealed record CreateMostWinDuringTheDayRequest(Guid JournalId, string message, string StrenghtName) { }
}

