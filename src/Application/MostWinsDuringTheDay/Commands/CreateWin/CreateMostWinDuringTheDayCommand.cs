namespace Application.MostWinsDuringTheDay.Command.CreateWin
{
    public sealed record CreateMostWinDuringTheDayCommand(Guid JournalId, string Message, string StrenghtName) : ICommand<MostWinDuringTheDayResponse>
    {
    }
}
