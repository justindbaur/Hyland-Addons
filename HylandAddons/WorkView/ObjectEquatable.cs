using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HylandAddons.WorkView
{
    public static class ObjectEquatable
    {
        public static bool IsMatch<T>(T item, Hyland.Unity.WorkView.Object wvObject, WorkViewMatchType matchType = WorkViewMatchType.OnlyKeys)
        {
            Type itemType = item.GetType();
            var definedAttributes = itemType.GetProperties().Where(pi => WorkViewAttributeAttribute.IsDefined(pi));

            List<PropertyInfo> matchableProperties = null;

            switch (matchType)
            {
                case WorkViewMatchType.OnlyKeys:
                    matchableProperties =definedAttributes.Where(pi => WorkViewAttributeAttribute.IsKey(pi)).ToList();
                    break;
                case WorkViewMatchType.NonOptional:
                    matchableProperties = definedAttributes.Where(pi => !WorkViewAttributeAttribute.IsOptional(pi)).ToList();
                    break;
                case WorkViewMatchType.AllDefinedAttributes:
                    matchableProperties = definedAttributes.ToList();
                    break;
                default:
                    break;
            }

            foreach (var matchProperty in matchableProperties)
            {
                var attributeValue = wvObject.AttributeValueByAddress(WorkViewAttributeAttribute.GetAttributeAddress(matchProperty));

                if (matchProperty.GetValue(item).ToString() != attributeValue.Value.ToString())
                {
                    return false;
                }
            }

            return true;
        }

        //public static bool IsMatch<T>(Func<T, Hyland.Unity.WorkView.Object, bool> predicate)
        //{
        //    return false;
        //}
    }
}
