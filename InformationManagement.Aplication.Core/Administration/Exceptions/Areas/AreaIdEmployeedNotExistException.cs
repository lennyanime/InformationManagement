using InformationManagement.Aplication.Core.Exceptions;

namespace InformationManagement.Aplication.Core.Administration.Exceptions.Areas
{
    public class AreaIdEmployeedNotExistException:ExceptionIM
    {
        public AreaIdEmployeedNotExistException()
        {

        }

        public AreaIdEmployeedNotExistException(string message):base(message)
        {

        }
    }
}
