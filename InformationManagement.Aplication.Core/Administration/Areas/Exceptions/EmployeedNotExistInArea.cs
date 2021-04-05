using InformationManagement.Aplication.Core.Exceptions;

namespace InformationManagement.Aplication.Core.Administration.Exceptions.Areas
{
    public class EmployeedNotExistInArea:ExceptionIM
    {
        public EmployeedNotExistInArea()
        {

        }

        public EmployeedNotExistInArea(string message):base(message)
        {

        }
    }
}
