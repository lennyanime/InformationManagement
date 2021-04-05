using System;
using System.Runtime.Serialization;

namespace InformationManagement.Aplication.Core.Administration.Clients.Services
{
    [Serializable]
    internal class IdClientAlreadyExist : Exception
    {
        public IdClientAlreadyExist()
        {
        }

        public IdClientAlreadyExist(string message) : base(message)
        {
        }

        public IdClientAlreadyExist(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IdClientAlreadyExist(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}