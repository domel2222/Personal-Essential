using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace Application.Abstractions.Messaging
{
    public interface IQueryHandler<in TQuery, TResoponse> 
        : IRequestHandler<TQuery, TResoponse> where TQuery : IQuery<TResoponse>
    {

    }
}
