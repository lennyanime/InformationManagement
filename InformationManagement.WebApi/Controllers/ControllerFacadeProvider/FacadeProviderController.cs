using InformationManagement.Aplication.Core.Administration.Providers.FacadeService;
using InformationManagement.Aplication.Dto.Administration.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationManagement.WebApi.Controllers.ControllerFacadeProvider
{
    public class FacadeProviderController
    {
        private readonly ILogger<FacadeProviderController> _logger;
        private readonly IFacadeServiceProvider _facadeProviderService;
        public FacadeProviderController(ILogger<FacadeProviderController> logger, IFacadeServiceProvider facadeProviderService)
        {
            _logger = logger;
            _facadeProviderService = facadeProviderService;
        }
        [HttpPost(nameof(AddProvider))]
        public async Task<ProviderDto> AddProvider(ProviderDto areaDto) =>
            await _facadeProviderService.ProviderManagementInsert(areaDto).ConfigureAwait(false);

        [HttpPost(nameof(UpdateProvider))]
        public async Task<ProviderDto> UpdateProvider(ProviderDto areaDto) =>
            await _facadeProviderService.ProviderManagementUpdate(areaDto).ConfigureAwait(false);

        [HttpPost(nameof(DeleteProvider))]
        public async Task<ProviderDto> DeleteProvider(ProviderDto areaDto) =>
            await _facadeProviderService.ProviderManagementDelete(areaDto).ConfigureAwait(false);

        [HttpPost(nameof(GetProvider))]
        public async Task<ProviderDto> GetProvider(ProviderDto areaDto) =>
            await _facadeProviderService.ProviderManagementGet(areaDto).ConfigureAwait(false);

        [HttpGet(nameof(GetAllProvider))]
        public async Task<IEnumerable<ProviderDto>> GetAllProvider() =>
            await _facadeProviderService.ProviderManagementGetAll().ConfigureAwait(false);
    }
}
