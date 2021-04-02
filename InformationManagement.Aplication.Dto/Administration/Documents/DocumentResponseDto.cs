using InformationManagement.Aplication.Dto.DataTransfer_Object;
using System;

namespace InformationManagement.Aplication.Dto.Administration.Documents
{
    public class DocumentResponseDto : DataTransferObject
    {
        public Guid TypeIdentificationId { get; set; }
        public string IdentificationName { get; set; }
    }
 
}
