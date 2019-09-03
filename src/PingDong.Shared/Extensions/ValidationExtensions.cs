using System;
using System.Collections.Generic;
using PingDong.Exception;

namespace PingDong.Validation
{
    public static class ValidationExtensions
    {
        /// <summary>
        /// Throws InvalidParameterException if target is null or default.
        /// </summary>
        /// <typeparam name="T">The data type of target</typeparam>
        /// <param name="target">The target value</param>
        /// <param name="parameterName">The name of parameter</param>
        public static void ThrowIfNullOrDefault<T>(this T target, string parameterName)
        {
            if (target == null)
                throw new InvalidParameterException(parameterName);

            if(EqualityComparer<T>.Default.Equals(target, default)) 
                throw new InvalidParameterException(parameterName);

            if (target is string targetString && string.IsNullOrWhiteSpace(targetString))
                throw new InvalidParameterException(parameterName);

            if (target is Guid targetGuid && targetGuid == Guid.Empty)
                throw new InvalidParameterException(parameterName);
        }
        
        /// <summary>
        /// Convert string to Guid, throws InvalidParameterException if fails.
        /// </summary>
        /// <param name="target">The target string</param>
        /// <param name="parameterName">The name of parameter</param>
        /// <returns></returns>
        public static Guid ThrowIfUnableToConvertToGuid(this string target, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(target))
                throw new InvalidParameterException(parameterName);
            
            if (!Guid.TryParse(target, out Guid idInGuid))
                throw new InvalidParameterException(parameterName);

            if (idInGuid == Guid.Empty)
                throw new InvalidParameterException(parameterName);
            
            return idInGuid;
        }

        /// <summary>
        /// Throws DataNotExistedException if target is null or default
        /// </summary>
        /// <param name="target">The target value</param>
        public static void ThrowIfMissing(this object target)
        {
            if (target == null)
                throw new DataNotExistedException();

            if (target == default)
                throw new DataNotExistedException();
        }

        /// <summary>
        /// Throws DataExistedException if target is not null
        /// </summary>
        /// <param name="target">The target value</param>
        public static void ThrowIfExisting(this object target)
        {
            if (target != null)
                throw new DataExistedException();
        }

        /// <summary>
        /// Throws InvalidParameterException if target is null or default.
        /// </summary>
        /// <typeparam name="T">The data type of target</typeparam>
        /// <param name="target">The target value</param>
        /// <param name="parameterName">The name of parameter</param>
        public static void EnsureNotNullOrDefault<T>(this T target, string parameterName)
        {
            if (target == null)
                throw new ArgumentNullException(parameterName);

            if(EqualityComparer<T>.Default.Equals(target, default)) 
                throw new ArgumentNullException(parameterName);

            if (target is string targetString && string.IsNullOrWhiteSpace(targetString))
                throw new ArgumentNullException(parameterName);

            if (target is Guid targetGuid && targetGuid == Guid.Empty)
                throw new ArgumentNullException(parameterName);
        }
    }
}
