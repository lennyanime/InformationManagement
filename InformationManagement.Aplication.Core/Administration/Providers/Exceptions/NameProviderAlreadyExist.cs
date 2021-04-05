using System;
using System.Runtime.Serialization;

namespace InformationManagement.Aplication.Core.Administration.Providers.Services
{
    [Serializable]
    internal class NameProviderAlreadyExist : Exception
    {
        public NameProviderAlreadyExist()
        {
        }

        public NameProviderAlreadyExist(string message) : base(message)
        {
        }

        public NameProviderAlreadyExist(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NameProviderAlreadyExist(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}