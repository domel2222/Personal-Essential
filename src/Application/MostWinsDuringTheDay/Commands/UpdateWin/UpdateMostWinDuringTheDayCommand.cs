namespace Application.MostWinsDuringTheDay.Commands.UpdateWin
{
    public sealed record UpdateMostWinDuringTheDayCommand (Guid MostWinId, string Message, string StrenghtName) : ICommand<Result<Unit>> { }
}
