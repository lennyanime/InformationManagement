using InformationManagement.Aplication.Dto.DataTransfer_Object;
using System;

namespace InformationManagement.Aplication.Dto.Administration
{
    public class PersonDto : DataTransferObject
    {
        public long DocumentNumber { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public virtual Type_Document TypeDocument { get; set; }
        public virtual TypeOfPerson TypePerson { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public DateTimeOffset SignUpDate { get; set; }
    }
    public enum TypeOfPerson
    {
        Natural ,
        Juridica ,
    }

    public enum Type_Document
    {
        Cedula,
        Pasaporte,
        Nit
    }
}

