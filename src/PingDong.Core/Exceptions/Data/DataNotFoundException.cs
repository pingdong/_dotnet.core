using System;

namespace PingDong.Data
{
    [Serializable]
    public class DataNotFoundException : ExposedException
    {
        public DataNotFoundException()
            : base("The target data doesn't exist")
        {
        }

        public DataNotFoundException(string message)
            : base(message)
        {
        }

        public DataNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected DataNotFoundException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
