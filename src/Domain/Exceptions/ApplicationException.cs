using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exeptions
{
    public abstract class ApplicationExeption : Exception
    {
        public string Title { get; }
        protected ApplicationExeption(string title, string message) 
            : base(message) 
        {
            Title = title;
        }
    }
}
