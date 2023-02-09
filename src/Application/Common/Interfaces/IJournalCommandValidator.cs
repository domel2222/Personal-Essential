namespace Application.Common.Interfaces
{
    public interface IJournalCommandValidator<T> : ICommandValidator<T>, IValidator<T>
    {
    }
}
