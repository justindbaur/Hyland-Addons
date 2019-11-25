using System;

namespace HylandAddons.WorkView
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IgnoreAttributeSerializationAttribute : Attribute { }
}
