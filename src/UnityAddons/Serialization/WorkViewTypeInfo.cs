using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnityAddons.Serialization
{
    public class WorkViewTypeInfo
    {
        internal Type Type { get; set; }
        internal Type RuntimeType { get; set; }
        internal WorkViewSerializationOptions Options { get; set; }
        internal WorkViewConverter Converter { get; set; }

        internal WorkViewTypeInfo(Type type, WorkViewSerializationOptions options)
            : this(type, 
                  GetConverter(type, null, null, out Type runtimeType, options), 
                  runtimeType, 
                  options)
        {
            
        }

        internal WorkViewTypeInfo(Type type, WorkViewConverter converter, Type runtimeType, WorkViewSerializationOptions options)
        {
            Type = type;
            Options = options;
            Converter = converter;
            RuntimeType = runtimeType;
        }



        private static WorkViewConverter GetConverter(Type type,
            Type parentClassType,
            MemberInfo memberInfo,
            out Type runtimeType,
            WorkViewSerializationOptions options)
        {
            // Validate?

            var converter = options.DetermineConverter(parentClassType, type, memberInfo);

            var converterRuntimeType = converter.RuntimeType;
            if (type == converterRuntimeType)
            {
                runtimeType = type;
            }
            else
            {

                if (type.IsInterface)
                {
                    runtimeType = converterRuntimeType;
                }
                else if (converterRuntimeType.IsInterface)
                {
                    runtimeType = type;
                }
                else
                {
                    // Use the most derived version from the converter.RuntimeType or converter.TypeToConvert.
                    if (type.IsAssignableFrom(converterRuntimeType))
                    {
                        runtimeType = converterRuntimeType;
                    }
                    else if (converterRuntimeType.IsAssignableFrom(type) || converter.TypeToConvert.IsAssignableFrom(type))
                    {
                        runtimeType = type;
                    }
                    else
                    {
                        runtimeType = default;
                        throw new NotSupportedException();
                    }
                }
            }

            return converter;
        }
    }
}
