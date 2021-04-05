using System;
using System.Runtime.Serialization;

namespace InformationManagement.Aplication.Core.Administration.Providers.Services
{
    [Serializable]
    internal class IdProviderEmployeeAlreadyExist : Exception
    {
        public IdProviderEmployeeAlreadyExist()
        {
        }

        public IdProviderEmployeeAlreadyExist(string message) : base(message)
        {
        }

        public IdProviderEmployeeAlreadyExist(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IdProviderEmployeeAlreadyExist(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}