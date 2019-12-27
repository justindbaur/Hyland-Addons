using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace UnityAddons.WorkView
{
    [AttributeUsage(AttributeTargets.Property)]
    public class WorkViewAttributeAttribute : Attribute
    {
        #region Private fields
        private readonly string _address = null;
        private WorkViewAttributeModifiers _modifiers = WorkViewAttributeModifiers.None;
        #endregion

        #region Constructors
        public WorkViewAttributeAttribute()
        {

        }

        public WorkViewAttributeAttribute(string address)
        {
            _address = address;
        }

        public WorkViewAttributeAttribute(string address, WorkViewAttributeModifiers modifiers) : this(address)
        {
            _modifiers = modifiers;
        }

        #endregion

        #region Properties
        [DefaultValue(null)]
        public string Address => _address;

        [DefaultValue(WorkViewAttributeModifiers.None)]
        public WorkViewAttributeModifiers Modifiers
        {
            get => _modifiers;
            set => _modifiers = value;
        }
        #endregion

        #region Static Helpers
        public static bool IsDefined(PropertyInfo propertyInfo)
        {
            if (propertyInfo is null)
            {
                throw new ArgumentNullException(nameof(propertyInfo));
            }

            return Attribute.IsDefined(propertyInfo, typeof(WorkViewAttributeAttribute));
        }

        public static string GetStringAddress(PropertyInfo propertyInfo)
        {
            if (propertyInfo is null)
            {
                throw new ArgumentNullException(nameof(propertyInfo));
            }

            return propertyInfo.GetCustomAttribute<WorkViewAttributeAttribute>()?.Address ?? propertyInfo.Name;
        }

        public static AttributeAddress GetAttributeAddress(PropertyInfo propertyInfo)
        {
            return new AttributeAddress(GetStringAddress(propertyInfo));
        }

        public static bool IsOptional(PropertyInfo propertyInfo)
        {
            if (propertyInfo is null)
            {
                throw new ArgumentNullException(nameof(propertyInfo));
            }


            if (!IsDefined(propertyInfo))
            {
                throw new InvalidOperationException(
                    $"{ nameof(WorkViewAttributeAttribute) } is not defined on property { propertyInfo.Name } on type { propertyInfo.DeclaringType.Name }");
            }

            return (propertyInfo.GetCustomAttribute<WorkViewAttributeAttribute>().Modifiers & WorkViewAttributeModifiers.Optional) == WorkViewAttributeModifiers.Optional;
        }

        public static bool IsKey(PropertyInfo propertyInfo)
        {
            if (propertyInfo is null)
            {
                throw new ArgumentNullException(nameof(propertyInfo));
            }

            if (!IsDefined(propertyInfo))
            {
                throw new InvalidOperationException(
                    $"{ nameof(WorkViewAttributeAttribute) } is not defined on property { propertyInfo.Name } on type { propertyInfo.DeclaringType.Name }");
            }

            return (propertyInfo.GetCustomAttribute<WorkViewAttributeAttribute>().Modifiers & WorkViewAttributeModifiers.Key) == WorkViewAttributeModifiers.Key;
        }

        public static IEnumerable<PropertyInfo> GetKeys<T>()
        {
            return GetKeys(typeof(T));
        }

        public static IEnumerable<PropertyInfo> GetKeys(Type type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return type.GetProperties().Where(prop => IsDefined(prop) && IsKey(prop));
        }
        #endregion
    }
}
