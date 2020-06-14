using System;
using System.Collections.Generic;
using System.Linq;

namespace PingDong.Validation
{
    [Serializable]
    public class ValidationFailedException : ExposedException
    {
        public ValidationFailedException()
            : base("Invalid data.")
        {
        }

        public ValidationFailedException(IEnumerable<ValidationError> errors)
            : this("Invalid data.", errors)
        {
        }

        public ValidationFailedException(string message, IEnumerable<ValidationError> errors)
            : this(message, errors, null)
        {
        }

        public ValidationFailedException(string message, IEnumerable<ValidationError> errors, Exception inner)
            : base(message, inner)
        {
            var validationErrors = errors as ValidationError[] ?? errors.ToArray();
            validationErrors.EnsureNotNull(nameof(errors));

            Errors = validationErrors;
        }

        public IEnumerable<ValidationError> Errors { get; }
    }
}
