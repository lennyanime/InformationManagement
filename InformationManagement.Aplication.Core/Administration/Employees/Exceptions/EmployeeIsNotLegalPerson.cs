using System;
using System.Runtime.Serialization;

namespace InformationManagement.Aplication.Core.Administration.Employees.Services
{
    [Serializable]
    internal class EmployeeIsNotLegalPerson : Exception
    {
        public EmployeeIsNotLegalPerson()
        {
        }

        public EmployeeIsNotLegalPerson(string message) : base(message)
        {
        }

        public EmployeeIsNotLegalPerson(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmployeeIsNotLegalPerson(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}