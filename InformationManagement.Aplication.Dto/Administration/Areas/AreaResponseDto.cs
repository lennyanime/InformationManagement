using InformationManagement.Aplication.Dto.DataTransfer_Object;
using System;

namespace InformationManagement.Aplication.Dto.Administration.Areas
{
    public class AreaResponseDto:DataTransferObject
    {
        public Guid AreaId { get; set; }
        
        public string AreaName { get; set; }

        public Guid ResponsableEmployedId { get; set; }
    }
}
