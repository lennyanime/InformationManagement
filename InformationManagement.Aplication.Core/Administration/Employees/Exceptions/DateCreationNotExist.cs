using System;
using System.Runtime.Serialization;

namespace InformationManagement.Aplication.Core.Administration.Employees.Services
{
    [Serializable]
    internal class DateCreationNotExist : Exception
    {
        public DateCreationNotExist()
        {
        }

        public DateCreationNotExist(string message) : base(message)
        {
        }

        public DateCreationNotExist(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DateCreationNotExist(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}