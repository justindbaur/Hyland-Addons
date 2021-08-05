using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityAddons.Serialization.Converters
{
    internal class BooleanConverter : WorkViewConverter<bool>
    {
        public override bool Read(ref WorkViewObjectReader reader, WorkViewSerializationOptions options)
        {
            return reader.GetBoolean();
        }

        public override void Write(ref WorkViewObjectWriter writer, bool value, WorkViewSerializationOptions options)
        {
            writer.WriteBoolean(value);
        }
    }
}
