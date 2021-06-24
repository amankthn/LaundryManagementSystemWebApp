using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLayer
{
    public class CustomerException : Exception
    {
        public CustomerException(string message) : base(message)
        {

        }
    }
}
