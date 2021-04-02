using InformationManagement.Aplication.Dto.Administration.Areas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationManagement.Aplication.Core.Administration.Areas
{
    public interface IAreaService
    {
        public Task<AreaDto> AddArea(AreaDto request);

        public Task<AreaDto> SearchAreaById(AreaDto request);
        public Task<bool> DeleteArea(AreaDto request);

        public Task<bool> UpdateArea(AreaDto request);

        public Task<IEnumerable<AreaDto>> GetAllAreaDto();
        
    }
}
