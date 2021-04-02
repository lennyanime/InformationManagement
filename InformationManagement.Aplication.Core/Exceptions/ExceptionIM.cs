using System;

namespace InformationManagement.Aplication.Core.Exceptions
{
    public class ExceptionIM:Exception
    {
        public ExceptionIM()
        {

        }

        public ExceptionIM(string? message) : base(message)
        {

        }
    }
}
