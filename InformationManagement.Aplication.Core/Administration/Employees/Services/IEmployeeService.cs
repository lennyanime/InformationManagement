using InformationManagement.Aplication.Dto.Administration.Employees;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationManagement.Aplication.Core.Administration.Employees.Services
{
    public interface IEmployeeService
    {
        public Task<EmployeeDto> AddEmployee(EmployeeDto request);

        public Task<EmployeeDto> SearchByIdEmployee(EmployeeDto request);

        public Task<bool> DeleteEmploye(EmployeeDto request);

        public Task<bool> UpdateEmployee(EmployeeDto request);

        public Task<IEnumerable<EmployeeDto>> GetAllEmployeeDto();
    }
}
