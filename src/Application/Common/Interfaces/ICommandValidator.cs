namespace Application.Common.Interfaces
{
    public interface ICommandValidator<T>
    {
        Task<ValidationResult> ValidateAsync(T command);
    }
}
