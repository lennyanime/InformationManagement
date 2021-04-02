using InformationManagement.Aplication.Dto.Administration.Employees;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationManagement.Aplication.Core.Administration.Employees.FacadeEmployeeService
{
    public interface IFacadeServiceEmployee
    {
        public Task<EmployeeDto> EmployeeManagementGet(EmployeeDto requestDto);
        public Task<EmployeeResponseDto> EmployeeManagementInsert(EmployeeDto requestDto);
        public Task<EmployeeResponseDto> EmployeeManagementDelete(EmployeeDto requestDto);
        public Task<EmployeeResponseDto> EmployeeManagementUpdate(EmployeeDto requestDto);
        public Task<IEnumerable<EmployeeDto>> EmployeeManagementGetAll();
    }
}
