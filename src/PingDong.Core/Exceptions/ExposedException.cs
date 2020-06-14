using System;

namespace PingDong
{
    [Serializable]
    public class ExposedException : Exception
    {
        public ExposedException()
        {
        }

        public ExposedException(string message)
            : base(message)
        {
        }

        public ExposedException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected ExposedException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
