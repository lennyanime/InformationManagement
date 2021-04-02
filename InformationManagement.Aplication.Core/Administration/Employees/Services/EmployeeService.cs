using AutoMapper;
using InformationManagement.Aplication.Dto.Administration.Employees;
using InformationManagement.Dominio.Core.Administracion.Personas;
using InformationManagement.Dominio.Core.Administration.Areas;
using InformationManagement.Dominio.Core.Administration.Empleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformationManagement.Aplication.Core.Administration.Employees.Services
{

    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepositorio _employeeRepo;
        private readonly IAreaRepositorio _areaRepo;
        public EmployeeService(IMapper mapper, IEmployeeRepositorio employeeRepo, IAreaRepositorio areaRepo)
        {
            _mapper = mapper;
            _employeeRepo = employeeRepo;
            _areaRepo = areaRepo;
        }
       
        public Task<bool> DeleteEmploye(EmployeeDto request)
        {
            ValidateDataNotNull(request);
            //var employeeAssignedToAArea = _areaRepo
            //    .SearchMatching<AreaEntity>(d => d.ResponsableEmployedId == request.EmployeeId).Any();

            //if (employeeAssignedToAArea)
            //    throw new DeleteEmployeeDenied_AssigedToAArea();

            var deleteEmployee = _employeeRepo
                .SearchMatching<EmployeeEntity>(e => e.EmployeeId == request.EmployeeId).FirstOrDefault();

            if (deleteEmployee == default || deleteEmployee == null)
                throw new DeleteEmployeeDenied();

            var response = _employeeRepo.Delete(_mapper.Map<EmployeeEntity>(deleteEmployee));
            return Task.FromResult(response);

        }

        public Task<IEnumerable<EmployeeDto>> GetAllEmployeeDto()
        {
            var employeeGetAll = _employeeRepo
               .GetAll<EmployeeEntity>();
            return Task.FromResult(_mapper.Map<IEnumerable<EmployeeDto>>(employeeGetAll));

        }

        public Task<EmployeeDto> SearchByIdEmployee(EmployeeDto request)
        {
            ValidateDataNotNull(request);
            var searchByIdEmployee = _employeeRepo
                .SearchMatching<EmployeeEntity>(id => id.EmployeeId == request.EmployeeId && id.EmployeeCode == request.EmployeeCode).FirstOrDefault();
            return Task.FromResult(_mapper.Map<EmployeeDto>(searchByIdEmployee));
        }

        public Task<bool> UpdateEmployee(EmployeeDto request)
        {
            ValidateDataNotNull(request);
            var updateEmployee = _employeeRepo
                .SearchMatching<EmployeeEntity>(u => u.EmployeeId == request.EmployeeId).FirstOrDefault();
            var response = _employeeRepo.Update(_mapper.Map<EmployeeEntity>(updateEmployee));
            return Task.FromResult(true);
        }

        public static void ValidateDataNotNull(EmployeeDto request)
        {
            if (request == null)
                throw new ArgumentNullException();
        }

        public async Task<EmployeeDto> AddEmployee(EmployeeDto request)
        {
            ValidateDataNotNull(request);

            var employeeGetAll = _employeeRepo
               .GetAll<EmployeeEntity>();
            var codeIdexist = employeeGetAll.Where(c=>c.EmployeeCode == request.EmployeeCode && c.EmployeeId == request.EmployeeId);

            var nameExist = employeeGetAll.Where(n => n.FirstName == request.FirstName && n.FirstLastName == request.FirstLastName
                                                    && n.SecondName == request.SecondName && n.SecondLastName == request.SecondLastName);

            if(codeIdexist.Any())
                throw new CodeIdEmployeeAlreadyExist();

            if (nameExist.Any())
                throw new NameEmployeeAlreadyExist();

            var response = await _employeeRepo.Insert(_mapper.Map<EmployeeEntity>(request)).ConfigureAwait(false);

            return _mapper.Map<EmployeeDto>(response);
        }
    }
}
