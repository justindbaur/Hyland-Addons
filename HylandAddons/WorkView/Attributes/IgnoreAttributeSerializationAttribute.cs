using System;

namespace HylandAddons.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IgnoreAttributeSerializationAttribute : System.Attribute { }
}
