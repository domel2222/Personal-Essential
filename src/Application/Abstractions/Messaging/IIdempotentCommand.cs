
namespace Application.Abstractions.Messaging
{
    public interface IIdempotentCommand<out TResponse> : ICommand<TResponse>
    {
        Guid ResquestId { get; set; }
    }
}
