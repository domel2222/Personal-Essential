namespace Domain.Exceptions
{
    public sealed class JournalNotFoundException : NotFoundException
    {
        public JournalNotFoundException(Guid journalId) : base($"The journal with the identifier {journalId} was not found")
        {
        }
    }
}
