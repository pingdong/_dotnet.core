using System;

namespace PingDong.Exception
{
    public class DataExistedException : ArgumentNullException
    {
        public DataExistedException() 
            : base("The target data exists.")
        {
        }

        public DataExistedException(string message) 
            : base(message)
        {
        }

        public DataExistedException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
