using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityAddons.Serialization
{
    public abstract class WorkViewConverter
    {
        internal WorkViewConverter() { }

        public abstract bool CanConvert(Type typeToConvert);

        internal abstract Type TypeToConvert { get; }
        internal virtual Type RuntimeType => TypeToConvert;

        public abstract bool TryReadAsObject(ref WorkViewObjectReader reader, WorkViewSerializationOptions options, out object value);

        public abstract bool TryWriteAsObject(ref WorkViewObjectWriter writer, object value, WorkViewSerializationOptions options);
    }
}
