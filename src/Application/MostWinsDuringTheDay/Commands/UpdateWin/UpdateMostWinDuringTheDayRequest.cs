namespace Application.MostWinsDuringTheDay.Commands.UpdateWin
{
    public sealed record UpdateMostWinDuringTheDayRequest (Guid MostWinId, string Message, string StrenghtName)
    {
    }
}
