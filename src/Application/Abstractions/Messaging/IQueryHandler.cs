
namespace Application.Abstractions.Messaging
{
    public interface IQueryHandler<in TQuery, TResoponse> 
        : IRequestHandler<TQuery, TResoponse> where TQuery : IQuery<TResoponse>
    {

    }
}
