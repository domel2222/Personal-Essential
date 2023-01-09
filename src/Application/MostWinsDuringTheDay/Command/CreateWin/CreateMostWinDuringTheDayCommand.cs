namespace Application.MostWinsDuringTheDay.Command.CreateWin
{
    public sealed record CreateMostWinDuringTheDayCommand(Guid JournalId, string message, string StrenghtName) : ICommand<MostWinDuringTheDayResponse>
    {
    }
}
