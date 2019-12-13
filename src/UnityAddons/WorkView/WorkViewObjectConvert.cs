using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UnityAddons.WorkView
{
    public static class WorkViewObjectConvert
    {
        /// <summary>
        /// Create a custom type from a WorkView object so it can be used in an OOP manner
        /// </summary>
        /// <typeparam name="T">Type of the object that should be created from the WorkView object</typeparam>
        /// <param name="wvObject">The WorkView object that contains the values to be used for Deserialization</param>
        /// <returns></returns>
        /// <exception cref="InvalidStringAddressException"></exception>
        public static T DeserializeWorkViewObject<T>(Hyland.Unity.WorkView.Object wvObject) where T : new()
        {
            // Create new instance of the desired object, item must have a constructor that takes 0 arguments
            var newItem = Activator.CreateInstance(typeof(T));

            var properties = typeof(T).GetProperties().Where(prop => WorkViewAttributeAttribute.IsDefined(prop));

            // Loop through properties
            foreach (var prop in properties)
            {
                // Initialize string address 
                string stringAddress = WorkViewAttributeAttribute.GetStringAddress(prop);

                // Try and get a value by the address
                var attributeValue = wvObject?.AttributeValueByAddress(stringAddress);

                // If the value could not be found or does not have a value
                if (attributeValue == null || !attributeValue.HasValue)
                {
                    // If item is optional, skip
                    if (!WorkViewAttributeAttribute.IsOptional(prop))
                    {
                        throw new InvalidStringAddressException(stringAddress);
                    }

                    continue;
                }

                prop.SetValue(newItem, attributeValue.Value);
            }

            // Return item
            return (T)newItem;
        }
    }
}
