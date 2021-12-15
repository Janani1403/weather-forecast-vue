using System;

namespace Forecast.Core.Exceptions
{
    /// <summary>
    /// Persistence layer exception
    /// </summary>
    [Serializable]
    public class PersistenceException : Exception
    {
        public PersistenceException(string message) : base(message)
        {
        }

        protected PersistenceException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {

        }
    }
}
