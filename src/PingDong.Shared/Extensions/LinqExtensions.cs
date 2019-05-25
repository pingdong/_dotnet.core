using System.Collections.Generic;
using System.Linq;

namespace PingDong.Linq
{
    public static class LinqExtensions
    {
        /// <summary>
        /// Is the source null or empty.
        /// </summary>
        /// <typeparam name="T">Type of element</typeparam>
        /// <param name="source">A list of elements</param>
        /// <returns>If the given list is null or empty, this method return True, otherwise False</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }
    }
}
