using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityAddons.Serialization.Converters
{
    internal class ObjectConverter<T> : WorkViewConverter
    {
        public ObjectConverter()
        {
            // Cache things


        }


        internal override Type TypeToConvert => typeof(T);

        public override bool CanConvert(Type typeToConvert)
        {
            return true;
        }

        public override bool TryReadAsObject(ref WorkViewObjectReader reader, WorkViewSerializationOptions options, out object value)
        {
            throw new NotImplementedException();
        }

        public override bool TryWriteAsObject(ref WorkViewObjectWriter writer, object value, WorkViewSerializationOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
