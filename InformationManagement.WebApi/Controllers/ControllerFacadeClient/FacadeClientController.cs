using InformationManagement.Aplication.Core.Administration.Clients.FacadeClientService;
using InformationManagement.Aplication.Dto.Administration.Clients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformationManagement.WebApi.Controllers.ControllerFacadeClient
{
    public class FacadeClientController : ControllerBase
    {
        private readonly ILogger<FacadeClientController> _logger;
        private readonly IFacadeServiceClient _facadeClientService;
        public FacadeClientController(ILogger<FacadeClientController> logger, IFacadeServiceClient facadeClientService)
        {
            _logger = logger;
            _facadeClientService = facadeClientService;
        }
        [HttpPost(nameof(AddClient))]
        public async Task<ClientDto> AddClient(ClientDto areaDto) =>
            await _facadeClientService.ClientManagementInsert(areaDto).ConfigureAwait(false);

        [HttpPost(nameof(UpdateClient))]
        public async Task<ClientDto> UpdateClient(ClientDto areaDto) =>
            await _facadeClientService.ClientManagementUpdate(areaDto).ConfigureAwait(false);

        [HttpPost(nameof(DeleteArea))]
        public async Task<ClientDto> DeleteArea(ClientDto areaDto) =>
            await _facadeClientService.ClientManagementDelete(areaDto).ConfigureAwait(false);

        [HttpPost(nameof(GetClient))]
        public async Task<ClientDto> GetClient(ClientDto areaDto) =>
            await _facadeClientService.ClientManagementGet(areaDto).ConfigureAwait(false);

        [HttpGet(nameof(GetAllClient))]
        public async Task<IEnumerable<ClientDto>> GetAllClient() =>
            await _facadeClientService.ClientManagementGetAll().ConfigureAwait(false);
    }
}
