using Hyland.Unity.WorkView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityAddons.WorkView
{
    public static class AttributeValueModifierHelper
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "This item is a extension parameter")]
        public static void SetAttributeValue(this AttributeValueModifier attributeValueModifier, Hyland.Unity.WorkView.Attribute attribute, object value)
        {
            if (attribute == null)
            {
                throw new ArgumentNullException(nameof(attribute));
            }

            switch (attribute.AttributeType)
            {
                case AttributeType.Document:
                case AttributeType.Relation:
                case AttributeType.Integer:
                    attributeValueModifier.SetAttributeValue(attribute, (long)value);
                    break;
                case AttributeType.Decimal:
                case AttributeType.Currency:
                    attributeValueModifier.SetAttributeValue(attribute, (decimal)value);
                    break;
                case AttributeType.Float:
                    attributeValueModifier.SetAttributeValue(attribute, (double)value);
                    break;
                case AttributeType.Date:
                case AttributeType.DateTime:
                    attributeValueModifier.SetAttributeValue(attribute, (DateTime)value);
                    break;
                case AttributeType.FormattedText:
                case AttributeType.Alphanumeric:
                case AttributeType.Text:
                    attributeValueModifier.SetAttributeValue(attribute, (string)value);
                    break;
                case AttributeType.Boolean:
                    attributeValueModifier.SetAttributeValue(attribute, (bool)value);
                    break;
                default:
                    break;
            }
        }
    }
}
