using System;
using System.Runtime.Serialization;

namespace InformationManagement.Infraestructura.Transversal.Exceptions
{
    public class HttpClientNotDefinedException : Exception
    {
        public HttpClientNotDefinedException() { }

        public HttpClientNotDefinedException(string message) : base(message)
        {

        }

        public HttpClientNotDefinedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }

    }
}
