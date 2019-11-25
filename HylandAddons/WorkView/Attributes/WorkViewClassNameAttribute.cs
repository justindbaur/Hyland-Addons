using System;

namespace HylandAddons.WorkView
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class WorkViewClassNameAttribute : Attribute
    {
        public string ClassName { get; }

        public WorkViewClassNameAttribute(string className)
        {
            ClassName = className;
        }
    }
}
