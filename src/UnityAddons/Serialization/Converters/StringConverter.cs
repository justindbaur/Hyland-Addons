using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyland.Unity.WorkView;

namespace UnityAddons.Serialization.Converters
{
    internal class StringConverter : WorkViewConverter<string>
    {
        public override string Read(ref WorkViewObjectReader reader, WorkViewSerializationOptions options)
        {
            switch (reader.TokenType)
            {
                case AttributeType.Alphanumeric:
                    return reader.GetAlphanumeric();
                case AttributeType.Text:
                    return reader.GetText();
                case AttributeType.FormattedText:
                    return reader.GetFormattedText();
                default:
                    throw new InvalidOperationException($"Cannot read attribute type '{reader.TokenType}' as string");
            }
        }

        public override void Write(ref WorkViewObjectWriter writer, string value, WorkViewSerializationOptions options)
        {
            writer.WriteString(value);
        }
    }
}
