using System;
using System.Runtime.Serialization;

namespace InformationManagement.Aplication.Core.Administration.Clients.Services
{
    [Serializable]
    internal class DeleteClientDenied : Exception
    {
        public DeleteClientDenied()
        {
        }

        public DeleteClientDenied(string message) : base(message)
        {
        }

        public DeleteClientDenied(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DeleteClientDenied(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}