using InformationManagement.Aplication.Core.Administration.Areas;
using InformationManagement.Aplication.Core.Administration.FacadeAreaService;
using InformationManagement.Aplication.Dto.Administration.Areas;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InformationManagement.Aplication.Core.Administration.FacadeAreaService
{
    public class FacadeServiceArea : IFacadeServiceArea
    {
        private readonly IAreaService _areaService; 
        public FacadeServiceArea(IAreaService areaService)
        {
            _areaService = areaService;
        }
        public async Task<AreaResponseDto> AreaManagementDelete(AreaDto requestDto)
        {
            var result = await _areaService.DeleteArea(requestDto).ConfigureAwait(false);
            return new AreaResponseDto
            {
                StatusCode = result ? HttpStatusCode.OK : HttpStatusCode.Unauthorized,
                StatusDescription = result ? "Ok":"Error"
            };
        }

        public Task<AreaDto> AreaManagementGet(AreaDto requestDto)
        {
            return _areaService.SearchAreaById(requestDto);
        }

        public Task<IEnumerable<AreaDto>> AreaManagementGetAll()
        {
            return _areaService.GetAllAreaDto();
        }

        public async Task<AreaResponseDto> AreaManagementInsert(AreaDto requestDto)
        {
            var result = await _areaService.AddArea(requestDto).ConfigureAwait(false);
            return new AreaResponseDto
            {
                StatusCode = result != default ? HttpStatusCode.OK : HttpStatusCode.Unauthorized,
                StatusDescription = result!= default? "Ok":"Error",
            };
        }

        public async Task<AreaResponseDto> AreaManagementUpdate(AreaDto requestDto)
        {
            var result = await _areaService.UpdateArea(requestDto).ConfigureAwait(false);
            return new AreaResponseDto
            {
                StatusCode = result ? HttpStatusCode.OK : HttpStatusCode.Unauthorized,
                StatusDescription = result ? "Ok" : "Error"
            };
        }
    }
}
