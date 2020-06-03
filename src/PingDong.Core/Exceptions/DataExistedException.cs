using System;

namespace PingDong
{
    public class DataExistedException : ArgumentException
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
