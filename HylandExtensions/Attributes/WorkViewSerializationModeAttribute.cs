using HylandAddons.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HylandAddons.Attributes
{
    [System.AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class WorkViewSerializationModeAttribute : System.Attribute
    {
        public WorkViewSerializationMode SerializationMode { get; }

        public WorkViewSerializationModeAttribute(WorkViewSerializationMode workViewSerializationMode)
        {
            SerializationMode = workViewSerializationMode;
        }
    }
}
