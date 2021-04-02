using System.Net;

namespace InformationManagement.Aplication.Dto.DataTransfer_Object
{
    public class DataTransferObject
    {
        public HttpStatusCode StatusCode { get; set; }
        public string StatusDescription { get; set; }
    }
}
