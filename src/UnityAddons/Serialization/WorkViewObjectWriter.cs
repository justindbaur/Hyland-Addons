using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyland.Unity.WorkView;

namespace UnityAddons.Serialization
{
    public ref struct WorkViewObjectWriter
    {
        private readonly Class _rootClass;
        private readonly Stack<Hyland.Unity.WorkView.Object> _objects;
        private readonly Stack<AttributeValueModifier> _attributeModifiers;
        private readonly Stack<Hyland.Unity.WorkView.Attribute> _attributes;

        public WorkViewObjectWriter(Class unityClass)
        {
            _rootClass = unityClass;
            _objects = new Stack<Hyland.Unity.WorkView.Object>();
            var startingObject = _rootClass.CreateObject();
            _objects.Push(startingObject);
            _attributeModifiers = new Stack<AttributeValueModifier>();
            _attributeModifiers.Push(startingObject.CreateAttributeValueModifier());
            _attributes = new Stack<Hyland.Unity.WorkView.Attribute>();
        }

        public AttributeType? TokenType => _attributes.Peek().AttributeType;

        public void WriteAttribute(string attributeName)
        {
            var attribute = _rootClass.Attributes.Find(attributeName);

            if (attribute == null)
            {
                throw new InvalidOperationException($"No such attribute by name '{attributeName}'");
            }

            if (_attributes.Count > 0)
            {
                _attributes.Pop();
            }

            _attributes.Push(attribute);
        }

        public void WriteBoolean(bool value)
        {
            ValidateWrite(AttributeType.Boolean, value);
            _attributeModifiers.Peek().SetAttributeValue(_attributes.Peek(), value);
        }

        public void WriteInteger(long value)
        {
            ValidateWrite(AttributeType.Integer, value);
            _attributeModifiers.Peek().SetAttributeValue(_attributes.Peek(), value);
        }

        public void WriteString(string value)
        {
            // TODO: Do full validate for string formats
            _attributeModifiers.Peek().SetAttributeValue(_attributes.Peek(), value);
        }

        public void WriteDateTime(DateTime value)
        {
            ValidateWrite(AttributeType.DateTime, value);
            _attributeModifiers.Peek().SetAttributeValue(_attributes.Peek(), value);
        }

        public void WriteDecimal(decimal value)
        {
            ValidateWrite(AttributeType.Decimal, value);
            _attributeModifiers.Peek().SetAttributeValue(_attributes.Peek(), value);
        }

        public void WriteDouble(double value)
        {
            // TODO: Do full validate for double types
            _attributeModifiers.Peek().SetAttributeValue(_attributes.Peek(), value);
        }

        public void WriteRelationship(long value)
        {
            ValidateWrite(AttributeType.Relation, value);
            _attributeModifiers.Peek().SetAttributeValue(_attributes.Peek(), value);
        }

        public Hyland.Unity.WorkView.Object FinishWriting()
        {
            if (_attributeModifiers.Count != 1)
            {
                throw new InvalidOperationException();
            }

            _attributeModifiers.Pop().ApplyChanges();

            if (_objects.Count != 1)
            {
                throw new InvalidOperationException();
            }

            return _objects.Pop();
        }

        public void StartObject()
        {
            if (TokenType != AttributeType.Relation)
            {
                throw new InvalidOperationException();
            }

            var currentAttribute = _attributes.Peek();
            var newObject = currentAttribute.RelatedClass.CreateObject();
            _attributeModifiers.Push(newObject.CreateAttributeValueModifier());
            _objects.Push(newObject);
        }

        public void EndObject()
        {
            var mod = _attributeModifiers.Pop();
            mod.ApplyChanges();

            var newObject = _objects.Pop();
            WriteRelationship(newObject.ID);
        }

        private void ValidateWrite(AttributeType attributeType, object value)
        {
            if (_attributes.Count == 0)
            {
                throw new InvalidOperationException($"Cannot write attribute value without first calling '{nameof(WriteAttribute)}'");
            }

            if (TokenType != attributeType)
            {
                throw new InvalidOperationException($"Value '{value}' cannot be assigned to attribute type '{attributeType}'");
            }
        }
    }
}
