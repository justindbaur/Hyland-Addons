using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityAddons.Serialization.Converters
{
    internal class DoubleConverter : WorkViewConverter<double>
    {
        public override double Read(ref WorkViewObjectReader reader, WorkViewSerializationOptions options)
        {
            return reader.GetDouble();
        }

        public override void Write(ref WorkViewObjectWriter writer, double value, WorkViewSerializationOptions options)
        {
            writer.WriteDouble(value);
        }
    }
}
