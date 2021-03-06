using InformationManagement.Aplication.Dto.DataTransfer_Object;
using System;

namespace InformationManagement.Aplication.Dto.Administration.Providers
{
    public class ProviderResponseDto : DataTransferObject
    {
        public Guid IdProvider { get; set; }
        public string CompanyName { get; set; }
        public long ContactNumber { get; set; }
    }
}
