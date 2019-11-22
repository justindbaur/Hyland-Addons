using System;
using System.Linq;

namespace HylandAddons.WorkView
{
    public static class WorkViewObjectConvert
    {
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
                var attributeValue = wvObject.AttributeValueByAddress(stringAddress);

                // See if the value is marked as optional
                var isOptional = WorkViewAttributeAttribute.IsOptional(prop);

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


                prop.SetValue(newItem, attributeValue.Value);
            }

            // Return item
            return (T)newItem;
        }

        //public static void SerializeObject<T>(Hyland.Unity.WorkView.Object wvObject, T item)
        //{
        //    var avm = wvObject.CreateAttributeValueModifier();


        //}
    }
}
