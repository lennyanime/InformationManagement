using System;
using System.Runtime.Serialization;

namespace InformationManagement.Aplication.Core.Administration.Employees.Services
{
    [Serializable]
    internal class EmployeeHaveNotNit : Exception
    {
        public EmployeeHaveNotNit()
        {
        }

        public EmployeeHaveNotNit(string message) : base(message)
        {
        }

        public EmployeeHaveNotNit(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmployeeHaveNotNit(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}