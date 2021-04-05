using AutoMapper;
using InformationManagement.Aplication.Core.Administration.Integration;
using InformationManagement.Aplication.Dto.Administration.Providers;
using InformationManagement.Dominio.Core.Administracion.Personas;
using InformationManagement.Dominio.Core.Administration.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformationManagement.Aplication.Core.Administration.Providers.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IMapper _mapper;
        private readonly IProviderRepositorio _providerRepo;
        private readonly IIntegrationServiceInformationManagement _integrationService;

        public ProviderService(IMapper mapper, IProviderRepositorio providerRepo , IIntegrationServiceInformationManagement integrationService)
        {
            _mapper = mapper;
            _providerRepo = providerRepo;
            _integrationService = integrationService;
        }
        public async Task<ProviderDto> AddProvider(ProviderDto request)
        {
            ValidateDataNotNull(request);
            var providerGetAll = _providerRepo
              .GetAll<ProviderEntity>();

            var nameEmployeeExist = providerGetAll.Where(n => n.FirstName == request.FirstName && n.FirstLastName == request.FirstLastName && n.SecondName == request.SecondName && n.SecondLastName == request.SecondLastName);

            var nameCompanyExist = providerGetAll.Where(c => c.CompanyName == request.CompanyName);

            var nitProviderExist = providerGetAll.Where(n => n.NitCompany == request.NitCompany);

            

            if (nameEmployeeExist.Any())
                throw new NameProviderAlreadyExist();
           
            if (request.TypeDocument.ToString().ToLower().Equals("Nit".ToLower()))
                throw new ProviderEmployeeHaveNotNit();
            
            if (nameCompanyExist.Any())
                throw new NameCompanyAlreadyExist();

            

            if (request.DateOfBirth == null || request.SignUpDate == null || request.DateOfBirth == default || request.SignUpDate == default)
                throw new DateCreationNotExistForProvider();

            if (nitProviderExist.Any())
                throw new NitProviderAlreadyExist();


            var response = await _providerRepo.Insert(_mapper.Map<ProviderEntity>(request)).ConfigureAwait(false);

            return _mapper.Map<ProviderDto>(response);
        }

        public Task<bool> DeleteProvider(ProviderDto request)
        {
            ValidateDataNotNull(request);
            var deleteProvider = _providerRepo
                .SearchMatching<ProviderEntity>(p => p.IdProvider == request.IdProvider).FirstOrDefault();

            if (deleteProvider == default || deleteProvider == null)
                throw new DeleteProviderDenied();

            var response = _providerRepo.Delete(_mapper.Map<ProviderEntity>(deleteProvider));
            return Task.FromResult(response);
        }

        public Task<IEnumerable<ProviderDto>> GetAllProviderDto()
        {
            var providerGetAll = _providerRepo
               .GetAll<ProviderEntity>();
            return Task.FromResult(_mapper.Map<IEnumerable<ProviderDto>>(providerGetAll));
        }

        public Task<ProviderDto> SearchByIdProvider(ProviderDto request)
        {
            ValidateDataNotNull(request);
            var searchByIdProvider = _providerRepo
                .SearchMatching<ProviderEntity>(id => id.IdProvider == request.IdProvider).FirstOrDefault();
            return Task.FromResult(_mapper.Map<ProviderDto>(searchByIdProvider));
        }

        public Task<bool> UpdateProvider(ProviderDto request)
        {
            ValidateDataNotNull(request);
            var searchByIdProvider = _providerRepo
               .SearchMatching<ProviderEntity>(id => id.IdProvider == request.IdProvider).FirstOrDefault();
            var response = _providerRepo.Update(_mapper.Map<ProviderEntity>(searchByIdProvider));
            return Task.FromResult(true);
        }

        public static void ValidateDataNotNull(ProviderDto request)
        {
            if (request == null)
                throw new ArgumentNullException();
        }

        public async Task<string> ExportAll()
        {
            var listentity = _providerRepo
                .GetAll<ProviderEntity>();

            return await _integrationService.ExportJson("ExportAllProviderDto", _mapper.Map<IEnumerable<ProviderDto>>(listentity)).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ProviderDto>> ImportAll()
        {
            var providerDto = await _integrationService.ImportJson<IEnumerable<ProviderDto>>("ExportAllProviderDto").ConfigureAwait(false);
            foreach (ProviderDto element in providerDto)
                await UpdateProvider(element).ConfigureAwait(false);
            return providerDto;
        }
    }
}
