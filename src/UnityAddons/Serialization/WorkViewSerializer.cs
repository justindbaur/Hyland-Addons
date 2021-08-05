using System;
using Hyland.Unity;

namespace UnityAddons.Serialization
{
    public static class WorkViewSerializer
    {
        public static object Deserialize(Hyland.Unity.WorkView.Object unityObject, Type returnType, WorkViewSerializationOptions options = null)
        {
            if (unityObject is null)
            {
                throw new ArgumentNullException(nameof(unityObject));
            }

            if (returnType is null)
            {
                throw new ArgumentNullException(nameof(returnType));
            }

            return Read(unityObject, GetTypeInfo(returnType, options));
        }

        public static T Deserialize<T>(Hyland.Unity.WorkView.Object unityObject, WorkViewSerializationOptions options = null)
        {
            if (unityObject is null)
            {
                throw new ArgumentNullException(nameof(unityObject));
            }

            return (T)Deserialize(unityObject, typeof(T), options);
        }

        public static Hyland.Unity.WorkView.Object Serialize<T>(T value, Hyland.Unity.WorkView.Class unityClass, WorkViewSerializationOptions options = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (unityClass is null)
            {
                throw new ArgumentNullException(nameof(unityClass));
            }

            return Write(value, unityClass, GetTypeInfo(typeof(T), options));
        }

        public static Hyland.Unity.WorkView.Object Serialize(object value, Type type, Hyland.Unity.WorkView.Class unityClass, WorkViewSerializationOptions options = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (unityClass is null)
            {
                throw new ArgumentNullException(nameof(unityClass));
            }

            return Write(value, unityClass, GetTypeInfo(type, options));
        }

        private static object Read(Hyland.Unity.WorkView.Object unityObject, WorkViewTypeInfo typeInfo)
        {
            var reader = new WorkViewObjectReader(unityObject);

            if (!typeInfo.Converter.TryReadAsObject(ref reader, typeInfo.Options, out var value))
            {
                throw new Exception("Could not convert");
            }

            return value;
        }

        private static Hyland.Unity.WorkView.Object Write(object value, Hyland.Unity.WorkView.Class unityClass, WorkViewTypeInfo typeInfo)
        {
            var writer = new WorkViewObjectWriter(unityClass);

            if (!typeInfo.Converter.TryWriteAsObject(ref writer, value, typeInfo.Options))
            {
                throw new Exception("Could not create unity object");
            }

            return writer.FinishWriting();
        }

        private static WorkViewTypeInfo GetTypeInfo(Type runtimeType, WorkViewSerializationOptions options)
        {
            options = options ?? WorkViewSerializationOptions._defaultOptions;
            return options.GetOrAddClassForRootType(runtimeType);
        }
    }
}
