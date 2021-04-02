using InformationManagement.Aplication.Core.Administration.Employees.Services;
using InformationManagement.Aplication.Dto.Administration.Employees;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace InformationManagement.Aplication.Core.Administration.Employees.FacadeEmployeeService
{
    public class FacadeServiceEmployee : IFacadeServiceEmployee
    {
        private readonly IEmployeeService _employeeService;
        public FacadeServiceEmployee(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<EmployeeResponseDto> EmployeeManagementDelete(EmployeeDto requestDto)
        {
            var result = await _employeeService.DeleteEmploye(requestDto).ConfigureAwait(false);
            return new EmployeeResponseDto
            {
                StatusCode = result ? HttpStatusCode.OK : HttpStatusCode.Unauthorized,
                StatusDescription = result ? "Ok":"Error"
            };
        }

        public Task<EmployeeDto> EmployeeManagementGet(EmployeeDto requestDto)
        {
            return _employeeService.SearchByIdEmployee(requestDto);
        }

        public Task<IEnumerable<EmployeeDto>> EmployeeManagementGetAll()
        {
            return _employeeService.GetAllEmployeeDto();
        }

        public async Task<EmployeeResponseDto> EmployeeManagementInsert(EmployeeDto requestDto)
        {
            var result = await _employeeService.AddEmployee(requestDto).ConfigureAwait(false);
            return new EmployeeResponseDto
            {
                StatusCode = result != default ? HttpStatusCode.OK : HttpStatusCode.Unauthorized,
                StatusDescription = result != default ? "Ok" : "Error",
            };
        }

        public async Task<EmployeeResponseDto> EmployeeManagementUpdate(EmployeeDto requestDto)
        {
            var result = await _employeeService.UpdateEmployee(requestDto).ConfigureAwait(false);
            return new EmployeeResponseDto
            {
                StatusCode = result ? HttpStatusCode.OK : HttpStatusCode.Unauthorized,
                StatusDescription = result ? "Ok" : "Error"
            };
        }
    }
}
