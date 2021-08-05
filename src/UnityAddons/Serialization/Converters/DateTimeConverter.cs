using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityAddons.Serialization.Converters
{
    internal class DateTimeConverter : WorkViewConverter<DateTime>
    {
        public override DateTime Read(ref WorkViewObjectReader reader, WorkViewSerializationOptions options)
        {
            return reader.GetDateTime();
        }

        public override void Write(ref WorkViewObjectWriter writer, DateTime value, WorkViewSerializationOptions options)
        {
            writer.WriteDateTime(value);
        }
    }
}
