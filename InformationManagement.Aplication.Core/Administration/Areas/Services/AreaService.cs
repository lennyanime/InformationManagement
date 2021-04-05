using AutoMapper;
using InformationManagement.Dominio.Core.Administracion.Personas;
using InformationManagement.Dominio.Core.Administration.Areas;
using InformationManagement.Dominio.Core.Administration.Empleado;
using InformationManagement.Dominio.Core.Areas;
using InformationManagement.Aplication.Core.Administration.Exceptions.Areas;
using InformationManagement.Aplication.Dto.Administration.Areas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformationManagement.Aplication.Core.Administration.Areas
{
    public class AreaService : IAreaService
    {
        private readonly IAreaRepositorio _areaRepo;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepositorio _employeeRepo;
        public AreaService(IAreaRepositorio arepo, IMapper mapper, IEmployeeRepositorio employeeRepo)
        {
            _areaRepo = arepo;
            _mapper = mapper;
            _employeeRepo = employeeRepo;
        }
        public async Task<AreaDto> AddArea(AreaDto request)
        {
            ValidationFields(request);

            if (request.ResponsableEmployedId == null || request.ResponsableEmployedId == default || request.AreaId == null || request.AreaId == default || request.AreaName == null || request.AreaName == default)
                throw new EmployeedNotExistInArea();

            var employeeExistInAnArea = _areaRepo
                .SearchMatching<AreaEntity>(e => e.ResponsableEmployedId == request.ResponsableEmployedId);

            if (employeeExistInAnArea.Any())
                throw new TheEmployeedAlreadyIsInAnArea();

            var response = await _employeeRepo.Insert(_mapper.Map<AreaEntity>(request)).ConfigureAwait(false);
            return _mapper.Map<AreaDto>(response);
        }

        public Task<bool> DeleteArea(AreaDto request)
        {
            ValidationFields(request);
            var deleteArea = _areaRepo
                .SearchMatching<AreaEntity>(d => d.AreaId == request.AreaId).FirstOrDefault();

            var employeeExist = _employeeRepo
                .SearchMatching<EmployeeEntity>(e => e.AreaId == request.AreaId).Any();
            if (employeeExist)
                throw new EmployeeExistInAreaException(request.AreaId);

            var response = _areaRepo.Delete(_mapper.Map<AreaEntity>(deleteArea));
            return Task.FromResult(response);
        }

        public Task<bool> UpdateArea(AreaDto request)
        {
            ValidationFields(request);
            var updateArea = _areaRepo
                .SearchMatching<AreaEntity>(d => d.AreaId == request.AreaId).FirstOrDefault();
            var response = _areaRepo.Update(_mapper.Map<AreaEntity>(updateArea));
            return Task.FromResult(response);

        }

        public Task<AreaDto> SearchAreaById(AreaDto request)
        {
            ValidationFields(request);

            var areaIdExist = _areaRepo
                .SearchMatching<AreaEntity>(id => id.AreaId == request.AreaId).FirstOrDefault();
            return Task.FromResult(_mapper.Map<AreaDto>(areaIdExist));
        }

        public Task<IEnumerable<AreaDto>> GetAllAreaDto()
        {
            var area = _areaRepo
                .GetAll<AreaEntity>();
            return Task.FromResult(_mapper.Map<IEnumerable<AreaDto>>(area));
        }
        private static void ValidationFields(AreaDto request)
        {
            if (request == null)
                throw new ArgumentNullException();
        }
    }
}
