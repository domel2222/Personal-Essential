namespace Application.Journals.Command.UpdateJournal
{
    public sealed record UpdateUserRequest(string Title, string Text, DateTime DiaryDate)
    {
    }
}
