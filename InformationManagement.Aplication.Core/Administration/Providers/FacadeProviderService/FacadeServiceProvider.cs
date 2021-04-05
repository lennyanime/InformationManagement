using InformationManagement.Aplication.Core.Administration.Providers.FacadeService;
using InformationManagement.Aplication.Core.Administration.Providers.Services;
using InformationManagement.Aplication.Dto.Administration.Providers;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace InformationManagement.Aplication.Core.Administration.Providers.FacadeProviderService
{
    public class FacadeServiceProvider : IFacadeServiceProvider
    {
        private readonly IProviderService _providerService;
        public FacadeServiceProvider(IProviderService providerService)
        {
            _providerService = providerService;
        }
        public async Task<ProviderDto> ProviderManagementDelete(ProviderDto requestDto)
        {
            var result = await _providerService.DeleteProvider(requestDto).ConfigureAwait(false);
            return new ProviderDto
            {
                StatusCode = result ? HttpStatusCode.OK : HttpStatusCode.Unauthorized,
                StatusDescription = result ? "Ok" : "Error"
            }; ;
        }

        public Task<ProviderDto> ProviderManagementGet(ProviderDto requestDto)
        {
            return _providerService.SearchByIdProvider(requestDto);
        }

        public Task<IEnumerable<ProviderDto>> ProviderManagementGetAll()
        {
            return _providerService.GetAllProviderDto();
        }

        public async Task<ProviderDto> ProviderManagementInsert(ProviderDto requestDto)
        {
            var result = await _providerService.AddProvider(requestDto).ConfigureAwait(false);
            return new ProviderDto
            {
                StatusCode = result != default ? HttpStatusCode.OK : HttpStatusCode.Unauthorized,
                StatusDescription = result != default ? "Ok" : "Error",
            };
        }

        public async Task<ProviderDto> ProviderManagementUpdate(ProviderDto requestDto)
        {
            var result = await _providerService.UpdateProvider(requestDto).ConfigureAwait(false);
            return new ProviderDto
            {
                StatusCode = result ? HttpStatusCode.OK : HttpStatusCode.Unauthorized,
                StatusDescription = result ? "Ok" : "Error"
            };
        }
    }
}
