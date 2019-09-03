using System;

namespace PingDong.Exception
{
    public class DataNotExistedException : ArgumentNullException
    {
        public DataNotExistedException() 
            : base("The target data doesn't exist")
        {
        }

        public DataNotExistedException(string message) 
            : base(message)
        {
        }

        public DataNotExistedException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
