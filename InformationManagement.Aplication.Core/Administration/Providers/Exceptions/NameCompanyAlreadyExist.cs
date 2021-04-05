using System;
using System.Runtime.Serialization;

namespace InformationManagement.Aplication.Core.Administration.Providers.Services
{
    [Serializable]
    internal class NameCompanyAlreadyExist : Exception
    {
        public NameCompanyAlreadyExist()
        {
        }

        public NameCompanyAlreadyExist(string message) : base(message)
        {
        }

        public NameCompanyAlreadyExist(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NameCompanyAlreadyExist(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}