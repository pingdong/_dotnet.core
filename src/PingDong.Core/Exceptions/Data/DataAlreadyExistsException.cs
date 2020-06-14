using System;

namespace PingDong.Data
{
    [Serializable]
    public class DataAlreadyExistsException : ExposedException
    {
        public DataAlreadyExistsException()
            : base("The target data already exists.")
        {
        }

        public DataAlreadyExistsException(string message)
            : base(message)
        {
        }

        public DataAlreadyExistsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
