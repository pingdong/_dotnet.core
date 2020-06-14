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
    }
}
