using System;
using System.Runtime.Serialization;

namespace InformationManagement.Aplication.Core.Administration.Clients.Services
{
    [Serializable]
    internal class DateCreationNotExistForClient : Exception
    {
        public DateCreationNotExistForClient()
        {
        }

        public DateCreationNotExistForClient(string message) : base(message)
        {
        }

        public DateCreationNotExistForClient(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DateCreationNotExistForClient(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}