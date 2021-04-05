using System;
using System.Runtime.Serialization;

namespace InformationManagement.Aplication.Core.Administration.Clients.Services
{
    [Serializable]
    internal class ClientHaveNotNit : Exception
    {
        public ClientHaveNotNit()
        {
        }

        public ClientHaveNotNit(string message) : base(message)
        {
        }

        public ClientHaveNotNit(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClientHaveNotNit(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}