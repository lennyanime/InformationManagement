using System;
using System.Runtime.Serialization;

namespace InformationManagement.Aplication.Core.Administration.Employees.Services
{
    [Serializable]
    internal class NotExistData : Exception
    {
        public NotExistData()
        {
        }

        public NotExistData(string message) : base(message)
        {
        }

        public NotExistData(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotExistData(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}