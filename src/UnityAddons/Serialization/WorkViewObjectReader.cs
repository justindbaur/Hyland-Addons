using Hyland.Unity.WorkView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityAddons.Serialization
{
    public ref struct WorkViewObjectReader
    {
        private Hyland.Unity.WorkView.Object _object;
        private int _index;
        private int _totalAttributes;

        public WorkViewObjectReader(Hyland.Unity.WorkView.Object unityObject)
        {
            _object = unityObject;
            _index = 0;
            _totalAttributes = unityObject.AttributeValues.Count;
        }

        public bool Read()
        {
            _index++;
            return _index < _totalAttributes;
        }

        public AttributeType TokenType
        {
            get
            {
                return _object.AttributeValues[_index].Attribute.AttributeType;
            }
        }

        public string GetName()
        {
            return _object.AttributeValues[_index].Attribute.Name;
        }

        public string GetAlphanumeric()
        {
            return _object.AttributeValues[_index].AlphanumericValue;
        }

        public long GetRelationship()
        {
            return _object.AttributeValues[_index].RelationshipValue;
        }

        public long GetInteger()
        {
            return _object.AttributeValues[_index].IntegerValue;
        }

        public bool GetBoolean()
        {
            return _object.AttributeValues[_index].BooleanValue;
        }

        public string GetText()
        {
            return _object.AttributeValues[_index].TextValue;
        }

        public string GetFormattedText()
        {
            return _object.AttributeValues[_index].FormattedTextValue;
        }

        public DateTime GetDateTime()
        {
            return _object.AttributeValues[_index].DateTimeValue;
        }

        public double GetDouble()
        {
            return _object.AttributeValues[_index].FloatingPointValue;
        }

        public decimal GetDecimal()
        {
            if (TokenType == AttributeType.Currency)
            {
                return _object.AttributeValues[_index].CurrencyValue;
            }

            return _object.AttributeValues[_index].DecimalValue;
        }
    }
}
