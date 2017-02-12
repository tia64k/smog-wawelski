using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmogWawelski.Exceptions
{
    public class SensorNotFoundException : Exception
    {
        public SensorNotFoundException()
        {
        }

        public SensorNotFoundException(string message)
        : base(message)
        {
        }

        public SensorNotFoundException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
