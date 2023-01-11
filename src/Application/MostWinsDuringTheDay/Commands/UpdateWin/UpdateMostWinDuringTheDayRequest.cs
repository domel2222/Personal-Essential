using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MostWinsDuringTheDay.Commands.UpdateWin
{
    public sealed record UpdateMostWinDuringTheDayRequest (Guid MostWinId, string Message, string StrenghtName)
    {
    }
}
