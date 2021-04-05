using InformationManagement.Dominio.Core.Administracion.Documento;
using System;
using System.ComponentModel.DataAnnotations;

namespace InformationManagement.Dominio.Core.Administration.Person
{
    public class ClientEntity : GeneralInformation
    {
        [Key]
        public Guid ClientId { get; set; }

        [Required]
        public string ClientName { get; set;}
        //RELACION CON TIPO DE IDENTIFICACION
        public Guid IdentificationId { get; set; }
        public DocumentTypeEntity DocumentId { get; set; }

    }
}
