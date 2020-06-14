using System;

namespace PingDong.Validation
{
    [Serializable]
    public class ValidationError
    {
        public string ErrorCode { get; set; }
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
