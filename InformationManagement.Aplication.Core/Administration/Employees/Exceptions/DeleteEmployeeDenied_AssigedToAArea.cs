using System;
using System.Runtime.Serialization;

namespace InformationManagement.Aplication.Core.Administration.Employees.Services
{
    [Serializable]
    internal class DeleteEmployeeDenied_AssigedToAArea : Exception
    {
        public DeleteEmployeeDenied_AssigedToAArea()
        {
        }

        public DeleteEmployeeDenied_AssigedToAArea(string message) : base(message)
        {
        }

        public DeleteEmployeeDenied_AssigedToAArea(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DeleteEmployeeDenied_AssigedToAArea(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}