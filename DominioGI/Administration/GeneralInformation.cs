using InformationManagement.Dominio.Core.Base;
using System;

namespace InformationManagement.Dominio.Core.Administration
{
    public abstract class GeneralInformation : EntidadBase
    {
        public long IdNumber { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public virtual KindOfPerson KindOfPerson { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public DateTimeOffset SignUpDate { get; set; }
    }
    public enum KindOfPerson
    {
        Natural = 1,
        Juridica = 2
    }
}

