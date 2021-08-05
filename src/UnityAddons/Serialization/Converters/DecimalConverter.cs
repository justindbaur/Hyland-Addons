using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityAddons.Serialization.Converters
{
    internal class DecimalConverter : WorkViewConverter<decimal>
    {
        public override decimal Read(ref WorkViewObjectReader reader, WorkViewSerializationOptions options)
        {
            return reader.GetDecimal();
        }

        public override void Write(ref WorkViewObjectWriter writer, decimal value, WorkViewSerializationOptions options)
        {
            writer.WriteDecimal(value);
        }
    }
}
