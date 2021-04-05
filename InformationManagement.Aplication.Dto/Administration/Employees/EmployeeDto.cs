using System;

namespace InformationManagement.Aplication.Dto.Administration.Employees
{
    public class EmployeeDto : PersonDto
    {
        public string job { get; set; }

        public Guid EmployeeId { get; set; }

        
        public Guid EmployeeCode { get; set; }
       
        public double Salary { get; set; }

        public Guid AreaId { get; set; }

        public Guid DocumentTypeId { get; set; }
    }

   
}
