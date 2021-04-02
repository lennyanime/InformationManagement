using InformationManagement.Aplication.Dto.Administration.Areas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InformationManagement.Aplication.Core.Administration.FacadeAreaService
{
    public interface IFacadeServiceArea
    {
        public Task<AreaDto> AreaManagementGet(AreaDto requestDto);
        public Task<AreaResponseDto> AreaManagementInsert(AreaDto requestDto);
        public Task<AreaResponseDto> AreaManagementDelete(AreaDto requestDto);
        public Task<AreaResponseDto> AreaManagementUpdate(AreaDto requestDto);
        public Task<IEnumerable<AreaDto>> AreaManagementGetAll();
    }
}
