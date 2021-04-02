using InformationManagement.Dominio.Core.Administracion.Personas;
using InformationManagement.Dominio.Core.Base;
using InformationManagement.Dominio.Core.Administration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InformationManagement.Dominio.Core.Areas
{
    public class AreaEntity : EntidadBase

    {
        [Key]
        public Guid AreaId { get; set; }

        [Required]
        public string AreaName { get; set; }

        [Required]
        [StringLength(30)]
        public Guid ResponsableEmployedId { get; set; }


        public IEnumerable<EmployeeEntity> AreaEmployees { get; set; }
    }
}
