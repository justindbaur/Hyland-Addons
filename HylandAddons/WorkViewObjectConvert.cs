using HylandAddons.Attributes;
using HylandAddons.Common;
using HylandAddons.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HylandAddons
{
    public static class WorkViewObjectConvert
    {
        public static T DeserializeWorkViewObject<T>(Hyland.Unity.WorkView.Object wvObject)
        {
            // Create new instance of the desired object, item must have a constructor that takes 0 arguments
            var newItem = (T)Activator.CreateInstance(typeof(T));
            var newType = typeof(T);

            var typeSerializationMode = WorkViewSerializationMode.OptOut;

            if (System.Attribute.IsDefined(newType, typeof(WorkViewSerializationModeAttribute)))
            {
                typeSerializationMode = (System.Attribute.GetCustomAttribute(newType, typeof(WorkViewSerializationModeAttribute)) as WorkViewSerializationModeAttribute).SerializationMode;
            }

            IEnumerable<System.Reflection.PropertyInfo> properties;

            // Get list of properties based on chosen mode
            switch (typeSerializationMode)
            {
                case WorkViewSerializationMode.OptOut:
                    // User want only properties that are not opted out to be included, so find ones where that attribute is not defined
                    properties = newType.GetProperties().Where(prop => !System.Attribute.IsDefined(prop, typeof(OptOutAttributeSerializationAttribute)));
                    break;
                case WorkViewSerializationMode.OptIn:
                    // User wants only properties that are opted in to be included, so only find properties where that is defined
                    properties = newType.GetProperties().Where(prop => System.Attribute.IsDefined(prop, typeof(OptInAttributeSerializationAttribute)));
                    break;
                default:
                    throw new NotImplementedException($"{ typeSerializationMode } is unknown.");
            }

            // Loop through properties
            foreach (var prop in properties)
            {
                // Initialize string address 
                string stringAddress;

                // Check if the user has specially defined by an attribute
                if (System.Attribute.IsDefined(prop, typeof(WorkViewAttributeAddressAttribute)))
                {
                    // Get the custom string address by the attribute
                    stringAddress = (prop.GetCustomAttributes(typeof(WorkViewAttributeAddressAttribute), false).First() as WorkViewAttributeAddressAttribute).StringAddress;
                }
                else
                {
                    // User property name
                    stringAddress = prop.Name;
                }

                // Try and get a value by the address
                var attributeValue = wvObject.AttributeValueByAddress(stringAddress);

                // See if the value is marked as optional
                var isOptional = System.Attribute.IsDefined(prop, typeof(OptionalAttributeValueAttribute));

                // If the value could not be found or does not have a value
                if (attributeValue == null || !attributeValue.HasValue)
                {
                    // If item is option, skip
                    if (!isOptional)
                    {
                        throw new InvalidStringAddressException(stringAddress);
                    }

                    continue;
                }

                // If the property is an enum we will try to convert a string to that enum.
                if (prop.PropertyType.IsEnum)
                {
                    var enumObject = Enum.Parse(Enum.GetUnderlyingType(prop.PropertyType), attributeValue.AlphanumericValue);
                    prop.SetValue(newItem, enumObject, null);
                }
                else
                {
                    prop.SetValue(newItem, attributeValue.Value, null);
                }
            }

            // Return item
            return newItem;
        }
    }
}
