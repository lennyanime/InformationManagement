using InformationManagement.Dominio.Core.Administracion.Documento;
using InformationManagement.Dominio.Core.Administration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InformationManagement.Dominio.Core.Administracion.Personas
{
    public class ProviderEntity: GeneralInformation
    {
        [Key]
        public Guid IdProvider { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public long ContactNumber { get; set; }

        //RELACION CON TIPO DE IDENTIFICACION
        public Guid KindOfIdentificationId { get; set; }
        public DocumentTypeEntity ProviderId { get; set; }
    }
}
