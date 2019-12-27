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
        public static T DeserializeWorkViewObject<T>(Hyland.Unity.WorkView.Object wvObject)
        {
            return (T)DeserializeWorkViewObject(wvObject, typeof(T));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="wvObject"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object DeserializeWorkViewObject(Hyland.Unity.WorkView.Object wvObject, Type type) where T : new()
        {
            if (wvObject is null)
            {
                throw new ArgumentNullException(nameof(wvObject));
            }

            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            // Create new instance of the desired object, item must have a constructor that takes 0 arguments
            var newItem = Activator.CreateInstance(type);

            var properties = type.GetProperties().Where(prop => WorkViewAttributeAttribute.IsDefined(prop));

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

            var systemProps = type.GetProperties().Where(prop => WorkViewSystemAttributeAttribute.IsDefined(prop));

            foreach (var prop in systemProps)
            {
                object value = null;

                switch (WorkViewSystemAttributeAttribute.GetSystemAttribute(prop))
                {
                    case WorkViewSystemAttribute.ID:
                        value = wvObject.ID;
                        break;
                    case WorkViewSystemAttribute.CreatedDate:
                        value = wvObject.CreatedDate;
                        break;
                    case WorkViewSystemAttribute.CreatedByID:
                        value = wvObject.CreatedBy.ID;
                        break;
                    case WorkViewSystemAttribute.CreatedByName:
                        value = wvObject.CreatedBy.Name;
                        break;
                    case WorkViewSystemAttribute.CreatedByRealName:
                        value = wvObject.CreatedBy.RealName;
                        break;
                    case WorkViewSystemAttribute.CreatedByDisplayName:
                        value = wvObject.CreatedBy.DisplayName;
                        break;
                    case WorkViewSystemAttribute.CreatedByEmailAddress:
                        value = wvObject.CreatedBy.EmailAddress;
                        break;
                    case WorkViewSystemAttribute.RevisionDate:
                        value = wvObject.RevisionDate;
                        break;
                    case WorkViewSystemAttribute.RevisionByID:
                        value = wvObject.RevisionBy.ID;
                        break;
                    case WorkViewSystemAttribute.RevisionByName:
                        value = wvObject.RevisionBy.Name;
                        break;
                    case WorkViewSystemAttribute.RevisionByRealName:
                        value = wvObject.RevisionBy.RealName;
                        break;
                    case WorkViewSystemAttribute.RevisionByDisplayName:
                        value = wvObject.RevisionBy.DisplayName;
                        break;
                    case WorkViewSystemAttribute.RevisionByEmailAddress:
                        value = wvObject.RevisionBy.EmailAddress;
                        break;
                    case WorkViewSystemAttribute.ClassID:
                        value = wvObject.Class.ID;
                        break;
                    case WorkViewSystemAttribute.ClassName:
                        value = wvObject.Class.Name;
                        break;
                    case WorkViewSystemAttribute.BaseClassID:
                        value = wvObject.BaseClassID;
                        break;
                    case WorkViewSystemAttribute.Name:
                        value = wvObject.Name;
                        break;
                    default:
                        continue;
                }

                prop.SetValue(newItem, value);
            }

            // Return item
            return newItem;
        }


    }
}
