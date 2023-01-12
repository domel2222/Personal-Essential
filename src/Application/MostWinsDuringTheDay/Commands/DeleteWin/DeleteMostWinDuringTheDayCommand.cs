namespace Application.MostWinsDuringTheDay.Commands.DeleteWin
{
    public sealed record DeleteMostWinDuringTheDayCommand(Guid MostWinId) : ICommand<Unit>
    {
    }
}
