using System;
using System.Runtime.Serialization;

namespace InformationManagement.Aplication.Core.Administration.Employees.Services
{
    [Serializable]
    internal class NameEmployeeAlreadyExist : Exception
    {
        public NameEmployeeAlreadyExist()
        {
        }

        public NameEmployeeAlreadyExist(string message) : base(message)
        {
        }

        public NameEmployeeAlreadyExist(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NameEmployeeAlreadyExist(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}