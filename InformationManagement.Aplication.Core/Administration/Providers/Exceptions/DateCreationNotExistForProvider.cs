using System;
using System.Runtime.Serialization;

namespace InformationManagement.Aplication.Core.Administration.Providers.Services
{
    [Serializable]
    internal class DateCreationNotExistForProvider : Exception
    {
        public DateCreationNotExistForProvider()
        {
        }

        public DateCreationNotExistForProvider(string message) : base(message)
        {
        }

        public DateCreationNotExistForProvider(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DateCreationNotExistForProvider(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}