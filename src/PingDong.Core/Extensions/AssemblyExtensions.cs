using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PingDong.Reflection
{
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Find all files in the specified folder 
        /// </summary>
        /// <param name="path">Search path</param>
        /// <param name="searchPattern">Search Pattern</param>
        /// <param name="searchOption">Search Option</param>
        /// <returns>All type that implement the specified interface</returns>
        public static IList<Assembly> Load(
            string path
            , string searchPattern = "*.dll"
            , SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(path))
                throw new ArgumentNullException(nameof(path));

            var files = Directory.EnumerateFiles(path, searchPattern, searchOption).ToList();

            if (!files.Any())
                return new List<Assembly>();

            var found = new ConcurrentBag<Assembly>();

            var query = from file in files.AsParallel()
                select file;

            try
            {
                query.ForAll(file => found.Add(Assembly.LoadFrom(file)));
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException != null)
                    throw ex.InnerException;
                if (ex.InnerExceptions.Any())
                    throw ex.InnerExceptions.First();
                throw;
            }

            return found.ToList();
        }
    }
}
