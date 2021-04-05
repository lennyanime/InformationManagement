using InformationManagement.Aplication.Dto.DataTransfer_Object;
using System;

namespace InformationManagement.Aplication.Dto.Administration.Documents
{
    public class DocumentDto : DataTransferObject
    {
        public Guid TypeIdentificationId { get; set; }
        public string IdentificationName { get; set; }

        public virtual TypeDocument TypeDocument {get; set;}
        
    }
    public enum TypeDocument
    {
        cedula = 1,
        pasaporte = 2,
        nit = 3
    }
}
