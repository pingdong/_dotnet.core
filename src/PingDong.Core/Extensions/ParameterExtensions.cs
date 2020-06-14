using PingDong.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PingDong
{
    public static class ParameterExtensions
    {
        /// <summary>
        /// Throws ArgumentNullException if the parameter is null.
        /// </summary>
        /// <typeparam name="T">The data type of parameter</typeparam>
        /// <param name="parameter">The parameter value</param>
        /// <param name="parameterName">The name of parameter</param>
        /// <exception cref="ArgumentNullException">The parameter is null</exception>
        public static void EnsureNotNull<T>(this T parameter, string parameterName = null)
        {
            if (parameter == null)
                throw new ArgumentNullException(parameterName);
        }

        /// <summary>
        /// Throws ArgumentNullException if the parameter is null or default.
        /// </summary>
        /// <typeparam name="T">The data type of parameter</typeparam>
        /// <param name="parameter">The parameter value</param>
        /// <param name="parameterName">The name of parameter</param>
        /// <exception cref="ArgumentNullException">The parameter is null or default</exception>
        public static void EnsureNotNullOrDefault<T>(this T parameter, string parameterName = null)
        {
            EnsureNotNull(parameter, parameterName);

            if (EqualityComparer<T>.Default.Equals(parameter, default))
                throw new ArgumentNullException(parameterName);
        }

        /// <summary>
        /// Throws ArgumentNullException if the parameter is null or default.
        /// </summary>
        /// <typeparam name="T">The data type of parameter</typeparam>
        /// <param name="parameter">The parameter value</param>
        /// <param name="parameterName">The name of parameter</param>
        /// <exception cref="ArgumentNullException">The parameter is null or doesn't have any item</exception>
        public static void EnsureNotNullOrEmptyCollection<T>(this IEnumerable<T> parameter, string parameterName = null)
        {
            if (parameter == null || !parameter.Any())
                throw new ArgumentNullException(parameterName);
        }

        /// <summary>
        /// Throws ArgumentNullException if the parameter is null or default.
        /// </summary>
        /// <typeparam name="T">The data type of parameter</typeparam>
        /// <param name="parameter">The parameter value</param>
        /// <param name="parameterName">The name of parameter</param>
        /// <exception cref="ArgumentNullException">The parameter is null or empty</exception>
        public static void EnsureNotNullOrEmpty<T>(this T parameter, string parameterName = null)
        {
            EnsureNotNull(parameter, parameterName);

            if (EqualityComparer<T>.Default.Equals(parameter, default))
                throw new ArgumentNullException(parameterName);

            if (parameter is string parameterString && string.IsNullOrEmpty(parameterString))
                throw new ArgumentNullException(parameterName);
        }

        /// <summary>
        /// Throws ArgumentNullException if the parameter is null or whitespace.
        /// </summary>
        /// <param name="parameter">The parameter value</param>
        /// <param name="parameterName">The name of parameter</param>
        /// <exception cref="ArgumentNullException">The parameter is null or whitespace</exception>
        public static void EnsureNotNullOrWhitespace(this string parameter, string parameterName = null)
        {
            if (string.IsNullOrWhiteSpace(parameter))
                throw new ArgumentNullException(parameterName);
        }

        /// <summary>
        /// Throws ArgumentException if the parameter is invalid.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="parameterName"></param>
        /// <exception cref="ArgumentNullException">The parameter is null</exception>
        /// <exception cref="ArgumentException">The parameter is invalid</exception>
        public static void EnsureNotNullAndValidated<T>(this T value, string parameterName = null)
            where T : IValidate
        {
            value.EnsureNotNull(parameterName);

            if (!value.IsValidated()) 
                throw new ArgumentException($"{parameterName} is invalid");
        }
        
        /// <summary>
        /// Convert string to Guid, throws exception if fails.
        /// </summary>
        /// <param name="parameter">The parameter string</param>
        /// <param name="parameterName">The name of parameter</param>
        /// <returns>Guid value</returns>
        /// <exception cref="ArgumentNullException">The parameter is null</exception>
        /// <exception cref="ArgumentException">The parameter was unable to convert to Guid</exception>
        public static Guid ToGuid(this string parameter, string parameterName = null)
        {
            parameter.EnsureNotNullOrWhitespace(parameterName);

            if (!Guid.TryParse(parameter, out Guid idInGuid))
                throw new ArgumentException(parameterName);

            return idInGuid;
        }
    }
}
