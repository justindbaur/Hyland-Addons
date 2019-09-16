using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HylandAddons.Exceptions
{
    public class InvalidStringAddressException : Exception
    {
        public string Address { get; }

        public InvalidStringAddressException(string address) : base($"Invalid string address: { address }")
        {
            Address = address;
        }
    }
}
