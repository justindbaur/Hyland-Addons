using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HylandAddons.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class WorkViewAttributeAddressAttribute : System.Attribute
    {
        public string StringAddress { get; }

        public WorkViewAttributeAddressAttribute(string stringAddress)
        {
            StringAddress = stringAddress;
        }
    }
}
