using System;
using System.Runtime.Serialization;

namespace InformationManagement.Aplication.Core.Administration.Providers.Services
{
    [Serializable]
    internal class DeleteProviderDenied : Exception
    {
        public DeleteProviderDenied()
        {
        }

        public DeleteProviderDenied(string message) : base(message)
        {
        }

        public DeleteProviderDenied(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DeleteProviderDenied(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}