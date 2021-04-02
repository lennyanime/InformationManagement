using System;
using System.Runtime.Serialization;

namespace InformationManagement.Aplication.Core.Administration.Employees.Services
{
    [Serializable]
    internal class CodeIdEmployeeAlreadyExist : Exception
    {
        public CodeIdEmployeeAlreadyExist()
        {
        }

        public CodeIdEmployeeAlreadyExist(string message) : base(message)
        {
        }

        public CodeIdEmployeeAlreadyExist(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CodeIdEmployeeAlreadyExist(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}