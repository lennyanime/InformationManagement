using InformationManagement.Aplication.Core.Administration.Employees.FacadeEmployeeService;
using InformationManagement.Aplication.Dto.Administration.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformationManagement.WebApi.Controllers.ControllerFacadeEmployee
{
    [ApiController]
    [Route("[controller]")]
    public class FacadeEmployeeController : ControllerBase
    {
        private readonly ILogger<FacadeEmployeeController> _logger;
        private readonly IFacadeServiceEmployee _facadeEmployeeService;

        public FacadeEmployeeController(ILogger<FacadeEmployeeController> logger , IFacadeServiceEmployee facadeEmployeeService)
        {
            _logger = logger;
            _facadeEmployeeService = facadeEmployeeService;
        }
        [HttpPost(nameof(AddEmployee))]
        public async Task<EmployeeResponseDto> AddEmployee(EmployeeDto employeeDto) =>
            await _facadeEmployeeService.EmployeeManagementInsert(employeeDto).ConfigureAwait(false);

        [HttpPost(nameof(UpdateEmployee))]
        public async Task<EmployeeResponseDto> UpdateEmployee(EmployeeDto areaDto) =>
            await _facadeEmployeeService.EmployeeManagementUpdate(areaDto).ConfigureAwait(false);

        [HttpPost(nameof(DeleteEmployee))]
        public async Task<EmployeeResponseDto> DeleteEmployee(EmployeeDto areaDto) =>
            await _facadeEmployeeService.EmployeeManagementDelete(areaDto).ConfigureAwait(false);

        [HttpPost(nameof(GetEmployee))]
        public async Task<EmployeeDto> GetEmployee(EmployeeDto employeeDto) =>
            await _facadeEmployeeService.EmployeeManagementGet(employeeDto).ConfigureAwait(false);

        [HttpGet(nameof(GetAllEmployee))]
        public async Task<IEnumerable<EmployeeDto>> GetAllEmployee() =>
            await _facadeEmployeeService.EmployeeManagementGetAll().ConfigureAwait(false);

    }
}
