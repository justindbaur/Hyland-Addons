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
        None = 0,
        Key = 1,
        Optional = 2
    }
}
