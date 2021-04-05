using System;
using System.Runtime.Serialization;

namespace InformationManagement.Aplication.Core.Administration.Providers.Services
{
    [Serializable]
    internal class ProviderEmployeeHaveNotNit : Exception
    {
        public ProviderEmployeeHaveNotNit()
        {
        }

        public ProviderEmployeeHaveNotNit(string message) : base(message)
        {
        }

        public ProviderEmployeeHaveNotNit(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ProviderEmployeeHaveNotNit(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}