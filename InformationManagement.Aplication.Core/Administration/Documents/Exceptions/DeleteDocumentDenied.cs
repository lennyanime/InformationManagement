using System;
using System.Runtime.Serialization;

namespace InformationManagement.Aplication.Core.Administration.Documents.Services
{
    [Serializable]
    internal class DeleteDocumentDenied : Exception
    {
        public DeleteDocumentDenied()
        {
        }

        public DeleteDocumentDenied(string message) : base(message)
        {
        }

        public DeleteDocumentDenied(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DeleteDocumentDenied(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}