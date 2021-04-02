using System;
using System.Runtime.Serialization;

namespace InformationManagement.Aplication.Core.Administration.Employees.Services
{
    [Serializable]
    internal class DeleteEmployeeDenied : Exception
    {
        public DeleteEmployeeDenied()
        {
        }

        public DeleteEmployeeDenied(string message) : base(message)
        {
        }

        public DeleteEmployeeDenied(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DeleteEmployeeDenied(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}