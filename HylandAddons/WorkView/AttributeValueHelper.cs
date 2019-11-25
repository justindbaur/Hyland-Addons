using Hyland.Unity.WorkView;
using System;

namespace HylandAddons
{
    public static class AttributeValueHelper
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

        public static string GetAlphanumericValue(this AttributeValue attributeValue)
        {
            if (attributeValue is null)
            {
                throw new ArgumentNullException(nameof(attributeValue));
            }

            return attributeValue.HasValue ? attributeValue.AlphanumericValue : null;
        }

        public static long? GetNullableIntegerValue(this AttributeValue attributeValue)
        {
            if (attributeValue is null)
            {
                throw new ArgumentNullException(nameof(attributeValue));
            }

            return attributeValue.HasValue ? attributeValue.IntegerValue : default(long?);
        }

        public static long GetIntegerValue(this AttributeValue attributeValue)
        {
            if (attributeValue is null)
            {
                throw new ArgumentNullException(nameof(attributeValue));
            }

            return attributeValue.GetNullableIntegerValue() ?? default(long);
        }

        public static decimal? GetNullableDecimalValue(this Hyland.Unity.WorkView.AttributeValue attributeValue)
        {
            switch (attributeValue.Attribute.AttributeType)
            {
                case AttributeType.Currency:
                    return attributeValue.HasValue ? attributeValue.CurrencyValue : default(decimal?);
                case AttributeType.Decimal:
                    return attributeValue.HasValue ? attributeValue.DecimalValue : default(decimal?);
                default:
                    throw new NotImplementedException("Invalid attribute type.");
            }
        }

        public static decimal GetDecimalValue(this AttributeValue attributeValue)
        {
            return attributeValue.GetNullableDecimalValue() ?? default(decimal);
        }

        public static double? GetNullableDoubleValue(this AttributeValue attributeValue)
        {
            return attributeValue.HasValue ? attributeValue.FloatingPointValue : default(double?);
        }

        public static double GetDoubleValue(this AttributeValue attributeValue)
        {
            return attributeValue.GetNullableDoubleValue() ?? default(double);
        }



        public static T GetValue<T>(this AttributeValue attributeValue)
        {
            return (T)attributeValue.Value;
        }

        public static bool TryGetValue<T>(this AttributeValue attributeValue, out T value)
        {
            bool success = true;

            try
            {
                value = (T)attributeValue.Value;
            }
            catch
            {
                value = default(T);
                success = false;
            }

            return success;
        }
    }
}
