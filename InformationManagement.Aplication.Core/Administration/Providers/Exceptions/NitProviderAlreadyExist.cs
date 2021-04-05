using System;
using System.Runtime.Serialization;

namespace InformationManagement.Aplication.Core.Administration.Providers.Services
{
    [Serializable]
    internal class NitProviderAlreadyExist : Exception
    {
        public NitProviderAlreadyExist()
        {
        }

        public NitProviderAlreadyExist(string message) : base(message)
        {
        }

        public NitProviderAlreadyExist(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NitProviderAlreadyExist(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}