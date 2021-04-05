using System;
using System.Runtime.Serialization;

namespace InformationManagement.Aplication.Core.Administration.Clients.Services
{
    [Serializable]
    internal class NameClientAlreadyExist : Exception
    {
        public NameClientAlreadyExist()
        {
        }

        public NameClientAlreadyExist(string message) : base(message)
        {
        }

        public NameClientAlreadyExist(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NameClientAlreadyExist(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}