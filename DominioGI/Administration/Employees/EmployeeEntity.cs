using InformationManagement.Dominio.Core.Administracion.Documento;
using InformationManagement.Dominio.Core.Areas;
using InformationManagement.Dominio.Core.Administration;
using System;
using System.ComponentModel.DataAnnotations;

namespace InformationManagement.Dominio.Core.Administracion.Personas
{
    public class EmployeeEntity : GeneralInformation
    {
        [Key]
        public Guid EmployeeId{ get; set; }

        [Required]
        public Guid EmployeeCode { get; set; }
        public override KindOfPerson KindOfPerson => KindOfPerson.Natural;
        
        public double Salary { get; set; }
        //falta migrar
        public string job { get; set; }

        //RELACION CON EL AREA
        public Guid AreaId { get; set; }
        public AreaEntity Area { get; set; }

        //RELACION CON TIPO DE IDENTIFICACION
        public Guid DocumentTypeId { get; set; }
        public DocumentTypeEntity DocumentType { get; set; }
    }
}
