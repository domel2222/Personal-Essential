
namespace Application.Abstractions.Messaging
{
    public interface IQuery<out IReaponse> : IRequest<IReaponse>
    {

    }
}
