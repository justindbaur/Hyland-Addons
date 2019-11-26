using System;

namespace HylandAddons.WorkView
{
    public enum WorkViewMatchType
    {
        OnlyKeys,
        NonOptional,
        AllDefinedAttributes
    }


    [Flags]
    public enum WorkViewAttributeModifiers
    {
        None = 0b0000,
        Key = 0b0001,
        Optional = 0b0010
    }
}
