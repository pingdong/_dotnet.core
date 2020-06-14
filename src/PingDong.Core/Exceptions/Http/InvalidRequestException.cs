using System;

namespace PingDong.Http
{
    [Serializable]
    public class InvalidRequestException : ExposedException
    {
        public InvalidRequestException()
            : base("The request is invalid")
        {
        }

        public InvalidRequestException(string message)
            : base(message)
        {
        }

        public InvalidRequestException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
