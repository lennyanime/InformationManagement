using InformationManagement.Aplication.Core.Administration.FacadeAreaService;
using InformationManagement.Aplication.Dto.Administration.Areas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationManagement.WebApi.Controllers.ControllerFacadeArea
{
    [ApiController]
    [Route("[controller]")]
    public class FacadeAreaController : ControllerBase
    {
        private readonly ILogger<FacadeAreaController> _logger;
        private readonly IFacadeServiceArea _facadeAreaService;
        public FacadeAreaController(ILogger<FacadeAreaController> logger, IFacadeServiceArea facadeAreaService)
        {
            _logger = logger;
            _facadeAreaService = facadeAreaService;
        }
        [HttpPost(nameof(AddArea))]
        public async Task<AreaResponseDto> AddArea(AreaDto areaDto) =>
            await _facadeAreaService.AreaManagementInsert(areaDto).ConfigureAwait(false); 

        [HttpPost(nameof(UpdateArea))]
        public async Task<AreaResponseDto> UpdateArea(AreaDto areaDto) =>
            await _facadeAreaService.AreaManagementUpdate(areaDto).ConfigureAwait(false);

        [HttpPost(nameof(DeleteArea))]
        public async Task<AreaResponseDto> DeleteArea(AreaDto areaDto) =>
            await _facadeAreaService.AreaManagementDelete(areaDto).ConfigureAwait(false);

        [HttpPost(nameof(GetArea))]
        public async Task<AreaDto> GetArea(AreaDto areaDto) =>
            await _facadeAreaService.AreaManagementGet(areaDto).ConfigureAwait(false);
        
        [HttpGet(nameof(GetAllArea))]
        public async Task<IEnumerable<AreaDto>> GetAllArea() =>
            await _facadeAreaService.AreaManagementGetAll().ConfigureAwait(false);
    }
}
