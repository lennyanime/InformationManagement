using System;
using System.Runtime.Serialization;

namespace InformationManagement.Aplication.Core.Administration.Integration.Exceptions
{
    [Serializable]
    internal class IntegrationArgumentPathException : Exception
    {
        public IntegrationArgumentPathException()
        {
        }

        public IntegrationArgumentPathException(string message) : base(message)
        {
        }

        public IntegrationArgumentPathException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IntegrationArgumentPathException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}