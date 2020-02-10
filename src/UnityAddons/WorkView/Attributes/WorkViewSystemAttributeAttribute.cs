using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnityAddons.WorkView
{
    [AttributeUsage(AttributeTargets.Property)]
    public class WorkViewSystemAttributeAttribute : Attribute
    {
        private WorkViewSystemAttribute _systemAttribute = WorkViewSystemAttribute.ID;

        [DefaultValue(WorkViewSystemAttribute.ID)]
        public WorkViewSystemAttribute SystemAttribute => _systemAttribute;


        public WorkViewSystemAttributeAttribute(WorkViewSystemAttribute systemAttribute)
        {
            _systemAttribute = systemAttribute;
        }

        public WorkViewSystemAttributeAttribute()
        {

        }

        public static bool IsDefined(PropertyInfo propertyInfo)
        {
            return Attribute.IsDefined(propertyInfo, typeof(WorkViewSystemAttributeAttribute));
        }

        public static WorkViewSystemAttribute GetSystemAttribute(PropertyInfo propertyInfo)
        {
            // TODO: Check that item is defined and not null

            return propertyInfo.GetCustomAttribute<WorkViewSystemAttributeAttribute>().SystemAttribute;
        }
    }
}
