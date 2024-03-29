﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared
{
    public class Error : IEqualityComparer<Error>
    {
        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public string Code { get; }
        public string Message{ get; }

        public static implicit operator string(Error error) => error.Code;

        public bool Equals(Error? x, Error? y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode([DisallowNull] Error obj)
        {
            throw new NotImplementedException();
        }
    }
}
