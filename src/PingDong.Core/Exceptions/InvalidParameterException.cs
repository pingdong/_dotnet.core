using System;

namespace PingDong
{
    public class InvalidParameterException : ArgumentException
    {
        public InvalidParameterException(string parameterName)
        {
            ParameterName = parameterName;
        }

        public InvalidParameterException(string parameterName, string message)
            : base(message)
        {
            ParameterName = parameterName;
        }

        public InvalidParameterException(string parameterName, string message, System.Exception inner)
            : base(message, inner)
        {
            ParameterName = parameterName;
        }

        public string ParameterName { get; }
    }
}
