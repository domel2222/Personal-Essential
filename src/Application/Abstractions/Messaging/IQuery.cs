﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace Application.Abstractions.Messaging
{
    public interface IQuery<out IReaponse> : IRequest<IReaponse>
    {

    }
}