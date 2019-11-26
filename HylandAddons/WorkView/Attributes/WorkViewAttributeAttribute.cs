using System;
using System.ComponentModel;
using System.Reflection;

namespace HylandAddons.WorkView
{
    [AttributeUsage(AttributeTargets.Property)]
    public class WorkViewAttributeAttribute : Attribute
    {
        #region Private fields
        private readonly string _address = null;
        private WorkViewAttributeModifiers _modifiers;
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
            if (!IsDefined(propertyInfo))
            {
                throw new InvalidOperationException(
                    $"{ nameof(WorkViewAttributeAttribute) } is not defined on property { propertyInfo.Name } on type { propertyInfo.DeclaringType.Name }");
            }

            return (propertyInfo.GetCustomAttribute<WorkViewAttributeAttribute>().Modifiers & WorkViewAttributeModifiers.Optional) == WorkViewAttributeModifiers.Optional;
        }

        public static bool IsKey(PropertyInfo propertyInfo)
        {
            if (!IsDefined(propertyInfo))
            {
                throw new InvalidOperationException(
                    $"{ nameof(WorkViewAttributeAttribute) } is not defined on property { propertyInfo.Name } on type { propertyInfo.DeclaringType.Name }");
            }

            return (propertyInfo.GetCustomAttribute<WorkViewAttributeAttribute>().Modifiers & WorkViewAttributeModifiers.Key) == WorkViewAttributeModifiers.Key;
        }
        #endregion
    }
}
