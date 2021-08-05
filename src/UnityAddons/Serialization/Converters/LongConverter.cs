using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityAddons.Serialization.Converters
{
    internal class LongConverter : WorkViewConverter<long>
    {
        public override long Read(ref WorkViewObjectReader reader, WorkViewSerializationOptions options)
        {
            return reader.GetInteger();
        }

        public override void Write(ref WorkViewObjectWriter writer, long value, WorkViewSerializationOptions options)
        {

        }
    }
}
