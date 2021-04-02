using InformationManagement.Dominio.Core.Administracion.Documento;
using InformationManagement.Dominio.Core.Administracion.Personas;
using InformationManagement.Dominio.Core.Administration;
using System;
using System.ComponentModel.DataAnnotations;

namespace InformationManagement.Dominio.Core.Administration.Person
{
    public class ClientEntity : GeneralInformation
    {
        [Key]
        public Guid ClientId { get; set; }
        [Required]
       
        //RELACION CON TIPO DE IDENTIFICACION
        public Guid IdentificationId { get; set; }
        public DocumentTypeEntity DocumentId { get; set; }

    }
}
