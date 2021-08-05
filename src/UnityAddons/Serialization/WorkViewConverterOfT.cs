using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityAddons.Serialization
{
    public abstract class WorkViewConverter<T> : WorkViewConverter
    {
        internal sealed override Type TypeToConvert => typeof(T);

        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(T);
        }

        public override bool TryReadAsObject(ref WorkViewObjectReader reader, WorkViewSerializationOptions options, out object value)
        {
            value = Read(ref reader, options);
            return true;
        }

        public override bool TryWriteAsObject(ref WorkViewObjectWriter writer, object value, WorkViewSerializationOptions options)
        {
            Write(ref writer, (T)value, options);
            return true;
        }

        public abstract T Read(ref WorkViewObjectReader reader, WorkViewSerializationOptions options);
        public abstract void Write(ref WorkViewObjectWriter writer, T value, WorkViewSerializationOptions options);
    }
}
