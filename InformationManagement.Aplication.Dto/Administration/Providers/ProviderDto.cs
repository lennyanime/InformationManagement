using InformationManagement.Aplication.Dto.DataTransfer_Object;
using System;

namespace InformationManagement.Aplication.Dto.Administration.Providers
{
    public class ProviderDto : PersonDto
    {
        public Guid IdProvider { get; set; }
        public string CompanyName { get; set; }
        public long ContactNumber { get; set; }
        public Guid NitCompany { get; set; }
    }
}
