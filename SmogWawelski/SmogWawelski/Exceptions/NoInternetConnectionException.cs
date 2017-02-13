using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmogWawelski.Exceptions
{
    class NoInternetConnectionException : Exception
    {
        public NoInternetConnectionException()
        {
        }

        public NoInternetConnectionException(string message)
        : base(message)
        {
        }

        public NoInternetConnectionException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
