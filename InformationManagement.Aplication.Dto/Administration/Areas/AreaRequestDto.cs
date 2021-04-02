using InformationManagement.Aplication.Dto.DataTransfer_Object;
using System;

namespace InformationManagement.Aplication.Dto.Administration.Areas
{
    public class AreaRequestDto:DataTransferObject
    {
        public string AreaName { get; set; }

        public Guid ResponsableEmployedId { get; set; }
    }
}
