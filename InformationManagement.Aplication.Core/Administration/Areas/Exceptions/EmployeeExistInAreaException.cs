using System;
using System.Runtime.Serialization;

namespace InformationManagement.Aplication.Core.Administration.Areas
{
    [Serializable]
    internal class EmployeeExistInAreaException : Exception
    {
        private Guid areaId;

        public EmployeeExistInAreaException()
        {
        }

        public EmployeeExistInAreaException(Guid areaId)
        {
            this.areaId = areaId;
        }

        public EmployeeExistInAreaException(string message) : base(message)
        {
        }

        public EmployeeExistInAreaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmployeeExistInAreaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}