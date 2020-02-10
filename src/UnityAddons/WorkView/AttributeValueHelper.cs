using Hyland.Unity.WorkView;

using System;
using System.Diagnostics.CodeAnalysis;

namespace UnityAddons.WorkView
{
    /// <summary>
    /// 
    /// </summary>
    public static class AttributeValueHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributeValue"></param>
        /// <returns></returns>
        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Extension Method")]
        public static string GetAlphanumericValue(this AttributeValue attributeValue)
        {
            if (attributeValue is null)
            {
                throw new ArgumentNullException(nameof(attributeValue));
            }

            return attributeValue.HasValue ? attributeValue.AlphanumericValue : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributeValue"></param>
        /// <returns></returns>
        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Extension Method")]
        public static long? GetNullableIntegerValue(this AttributeValue attributeValue)
        {
            if (attributeValue is null)
            {
                throw new ArgumentNullException(nameof(attributeValue));
            }

            return attributeValue.HasValue ? attributeValue.IntegerValue : default(long?);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributeValue"></param>
        /// <returns></returns>
        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Extension Method")]
        public static long GetIntegerValue(this AttributeValue attributeValue)
        {
            if (attributeValue is null)
            {
                throw new ArgumentNullException(nameof(attributeValue));
            }

            return attributeValue.GetNullableIntegerValue() ?? default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributeValue"></param>
        /// <returns></returns>
        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Extension Method")]
        public static decimal? GetNullableDecimalValue(this Hyland.Unity.WorkView.AttributeValue attributeValue)
        {
            switch (attributeValue.Attribute.AttributeType)
            {
                case AttributeType.Currency:
                    return attributeValue.HasValue ? attributeValue.CurrencyValue : default(decimal?);
                case AttributeType.Decimal:
                    return attributeValue.HasValue ? attributeValue.DecimalValue : default(decimal?);
                default:
                    return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributeValue"></param>
        /// <returns></returns>
        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Extension Method")]
        public static decimal GetDecimalValue(this AttributeValue attributeValue)
        {
            return attributeValue.GetNullableDecimalValue() ?? default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributeValue"></param>
        /// <returns></returns>
        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Extension Method")]
        public static double? GetNullableDoubleValue(this AttributeValue attributeValue)
        {
            return attributeValue.HasValue ? attributeValue.FloatingPointValue : default(double?);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributeValue"></param>
        /// <returns></returns>
        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Extension Method")]
        public static double GetDoubleValue(this AttributeValue attributeValue)
        {
            return attributeValue.GetNullableDoubleValue() ?? default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="attributeValue"></param>
        /// <returns></returns>
        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Extension Method")]
        public static T GetValue<T>(this AttributeValue attributeValue)
        {
            return (T)attributeValue.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="attributeValue"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Extension Method")]
        public static bool TryGetValue<T>(this AttributeValue attributeValue, out T value)
        {
            bool success = true;

            try
            {
                value = (T)attributeValue.Value;
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch
#pragma warning restore CA1031 // Do not catch general exception types
            {
                value = default;
                success = false;
            }

            return success;
        }
    }
}
