using System;
using System.Runtime.Serialization;

namespace UnityAddons.WorkView
{
    [Serializable]
    public class InvalidStringAddressException : Exception
    {
        public string Address { get; }

        public InvalidStringAddressException(string address) : this(address, null)
        {
        }

        public InvalidStringAddressException(string address, Exception innerException) : base($"Invalid string address: { address }", innerException)
        {
            Address = address;
        }

        protected InvalidStringAddressException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }

        public InvalidStringAddressException() : this("Unknown")
        { }
    }
}
