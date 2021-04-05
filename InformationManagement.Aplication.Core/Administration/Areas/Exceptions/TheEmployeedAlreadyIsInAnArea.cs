using System;
using System.Runtime.Serialization;

namespace InformationManagement.Aplication.Core.Administration.Areas
{
    [Serializable]
    internal class TheEmployeedAlreadyIsInAnArea : Exception
    {
        public TheEmployeedAlreadyIsInAnArea()
        {
        }

        public TheEmployeedAlreadyIsInAnArea(string message) : base(message)
        {
        }

        public TheEmployeedAlreadyIsInAnArea(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TheEmployeedAlreadyIsInAnArea(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}