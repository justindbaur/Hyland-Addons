using Hyland.Unity.WorkView;

using System;

namespace HylandAddons.WorkView
{
    public static class AttributeValueHelper
    {
        

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
                    return null;
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
