﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Messaging
{
    public interface IIdempotentCommand<out TResponse> : ICommand<TResponse>
    {
        Guid ResquestId { get; set; }
    }
}
