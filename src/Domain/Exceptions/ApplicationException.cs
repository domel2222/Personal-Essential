using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public abstract class ApplicationException : Exception
    {
        public string Title { get; }
        protected ApplicationException(string title, string message) 
            : base(message) 
        {
            Title = title;
        }
    }
}
