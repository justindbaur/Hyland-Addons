using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HylandAddons.Attributes
{
    [System.AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class WorkViewClassNameAttribute : System.Attribute
    {
        public string ClassName { get; }

        public WorkViewClassNameAttribute(string className)
        {
            ClassName = className;
        }
    }
}
