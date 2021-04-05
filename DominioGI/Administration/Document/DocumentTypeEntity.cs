using InformationManagement.Dominio.Core.Administracion.Personas;
using InformationManagement.Dominio.Core.Administration.Person;
using InformationManagement.Dominio.Core.Base;
using InformationManagement.Dominio.Core.Administration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InformationManagement.Dominio.Core.Administracion.Documento
{
    public class DocumentTypeEntity: EntidadBase
    {
        [Key]
        public Guid TypeIdentificationId { get; set; }
        
        public string IdentificationName { get; set; }

        public virtual TypeDocument TypeDocument { get; set; }

        public IEnumerable<ProviderEntity> ProvidersList { get; set; }
        public IEnumerable<ClientEntity> ClientsList { get; set; }
        public IEnumerable<EmployeeEntity> EmployeesList { get; set; }
       

    }
    public enum TypeDocument
    {
        cedula = 1,
        pasaporte = 2,
        nit = 3
    }

}
