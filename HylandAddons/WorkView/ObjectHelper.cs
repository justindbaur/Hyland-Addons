using Hyland.Unity.WorkView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HylandAddons.WorkView
{
    public static class ObjectHelper
    {
        /// <summary>
        /// Find an attribute value by a full path. Will return null if the attribute could not be found or the address is an invalid format
        /// </summary>
        /// <param name="wvObject">Starting object that is used to trace the string address to the final attribute value</param>
        /// <param name="address"></param>
        /// <returns></returns>
        public static AttributeValue AttributeValueByAddress(this Hyland.Unity.WorkView.Object wvObject, AttributeAddress address)
        {
            if (wvObject is null)
            {
                throw new ArgumentNullException(nameof(wvObject));
            }

            if (address is null)
            {
                throw new ArgumentNullException(nameof(address));
            }


            try
            {
                if (address.Depth == -1)
                {
                    throw new InvalidOperationException($"String Address: { address.ToString() } is in an invalid format.");
                }

                if (address.Depth == 0)
                {
                    return wvObject.AttributeValues.Find(address.FinalAttribute);
                }

                var relatedObject = wvObject.GetRelatedObject(address.NavigationPath);

                if (relatedObject == null)
                {
                    throw new InvalidOperationException($"Could not find a related object by string { address.NavigationPath } on object { wvObject.Name }");
                }

                return relatedObject.AttributeValues.Find(address.FinalAttribute);
            }
            catch
            {
                if (address.IgnoreErrors)
                {
                    return null;
                }

                throw;
            }
        }

        /// <summary>
        /// Find an attribute value by a full path. Will return null if the attribute could not be found or the address is an invalid format
        /// </summary>
        /// <param name="wvObject">Starting object that is used to trace the string address to the final attribute value</param>
        /// <param name="address">String address that contains a character (.) between each progressing attribute name</param>
        /// <returns></returns>
        public static AttributeValue AttributeValueByAddress(this Hyland.Unity.WorkView.Object wvObject, string address)
        {
            return AttributeValueByAddress(wvObject, new AttributeAddress(address));
        }

        /// <summary>
        /// Find an attribute value by a full path. Will return null if the attribute could not be found or the address is an invalid format
        /// </summary>
        /// <param name="wvObject">Starting object that is used to trace the string address to the final attribute value</param>
        /// <param name="addresses">Address array that contains the attribute names of each progressing class</param>
        /// <returns></returns>
        public static AttributeValue AttributeValueByAddress(this Hyland.Unity.WorkView.Object wvObject, params string[] addresses)
        {
            return AttributeValueByAddress(wvObject, new AttributeAddress(addresses));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="wvObject"></param>
        /// <param name="item"></param>
        /// <param name="matchType"></param>
        /// <returns></returns>
        public static bool IsMatch<T>(this Hyland.Unity.WorkView.Object wvObject, T item, WorkViewMatchType matchType = WorkViewMatchType.OnlyKeys)
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

            // 
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
    }
}
