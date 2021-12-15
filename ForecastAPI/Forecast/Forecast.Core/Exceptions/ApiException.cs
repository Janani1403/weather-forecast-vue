using System;

namespace Forecast.Core.Exceptions
{
    /// <summary>
    /// Api layer exception
    /// </summary>
    [Serializable]
    public class ApiException : Exception
    {
        public ApiException(string message) : base(message)
        {
        }

        protected ApiException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }
    }
}
