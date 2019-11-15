using System;

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
