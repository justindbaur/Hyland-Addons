using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Hyland.Unity.WorkView;
using UnityAddons.Serialization.Converters;
using UnityAddons.Serialization.Metadata;

namespace UnityAddons.Serialization
{
    public class WorkViewSerializationOptions
    {
        internal static readonly WorkViewSerializationOptions _defaultOptions = new WorkViewSerializationOptions();
        private static Dictionary<Type, WorkViewConverter> _defaultSimpleConverters = new Dictionary<Type, WorkViewConverter>();

        private readonly ConcurrentDictionary<Type, WorkViewTypeInfo> _classes = new ConcurrentDictionary<Type, WorkViewTypeInfo>();
        private readonly ConcurrentDictionary<Type, WorkViewConverter> _converters = new ConcurrentDictionary<Type, WorkViewConverter>();

        private WorkViewTypeInfo _lastClass { get; set; }


        public WorkViewSerializationOptions()
        {

        }

        public WorkView WorkView { get; set; }
        public bool IsWorkViewAccessEnabled => WorkView is not null;

        private void RootBuiltInConverters()
        {
            _defaultSimpleConverters = _defaultSimpleConverters ?? GetDefaultSimpleConverters();
        }

        private static Dictionary<Type, WorkViewConverter> GetDefaultSimpleConverters()
        {
            var converters = new Dictionary<Type, WorkViewConverter>();

            Add(WorkViewMetadataServices.StringConverter);
            Add(WorkViewMetadataServices.BooleanConverter);
            Add(WorkViewMetadataServices.LongConverter);
            Add(WorkViewMetadataServices.DateTimeConverter);
            Add(WorkViewMetadataServices.DecimalConverter);
            Add(WorkViewMetadataServices.DoubleConverter);

            return converters;

            void Add(WorkViewConverter converter) =>
                converters.Add(converter.TypeToConvert, converter);
        }

        internal WorkViewTypeInfo GetOrAddClass(Type type)
        {
            if (!_classes.TryGetValue(type, out WorkViewTypeInfo result))
            {
                _classes.GetOrAdd(type, new WorkViewTypeInfo(type, this));
            }

            return result;
        }

        internal WorkViewTypeInfo GetOrAddClassForRootType(Type type)
        {
            WorkViewTypeInfo typeInfo = _lastClass;

            if (typeInfo?.Type != type)
            {
                typeInfo = GetOrAddClass(type);
                _lastClass = typeInfo;
            }

            return typeInfo;
        }

        internal WorkViewConverter DetermineConverter(Type parentClassType, Type runtimePropertyType, MemberInfo memberInfo)
        {
            WorkViewConverter converter = null;

            if (memberInfo != null)
            {
                // TODO: Try to get it from an attribute
            }

            if (converter == null)
            {
                converter = GetConverterInternal(runtimePropertyType);
            }

            return converter;
        }

        private WorkViewConverter GetConverterInternal(Type typeToConvert)
        {
            if (_converters.TryGetValue(typeToConvert, out var converter))
            {
                return converter;
            }

            // Do some attribute stuff

            if (_defaultSimpleConverters.TryGetValue(typeToConvert, out converter))
            {
                _converters.TryAdd(typeToConvert, converter);
                return converter;
            }

            // TODO: Handle enums
            if (typeToConvert.IsValueType)
            {
                throw new NotImplementedException();
            }

            // Fallback
            converter = (WorkViewConverter)Activator.CreateInstance(typeof(ObjectConverter<>).MakeGenericType(typeToConvert));

            // This might be null
            return converter;
        }
    }
}
