using InformationManagement.Aplication.Dto.DataTransfer_Object;
using System;

namespace InformationManagement.Aplication.Dto.Administration.Employees
{
    public class EmployeeResponseDto : DataTransferObject
    {
        public Guid EmployeeId { get; set; }

        public Guid EmployeeCode { get; set; }

        public string FirstName { get; set; }
    }
}
