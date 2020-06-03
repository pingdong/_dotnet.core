using System;

namespace PingDong
{
    public class InvalidContentException : ArgumentException
    {
        public InvalidContentException()
            : base("The received data is invalid")
        {
        }

        public InvalidContentException(string message)
            : base(message)
        {
        }

        public InvalidContentException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
