using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Concurrent;
using PingDong.Linq;

namespace PingDong.IO
{
    /// <summary>
    /// Extension for IO
    /// </summary>
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Find all files in the specified folder 
        /// </summary>
        /// <param name="path">Search path</param>
        /// <param name="searchPattern">Search Pattern</param>
        /// <param name="searchOption">Search Option</param>
        /// <returns>All type that implement the specified interface</returns>
        public static IEnumerable<string> Filter(this string path,
            string searchPattern = "*",
            SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(path))
                throw new ArgumentNullException(nameof(path));

            var files = Directory.EnumerateFiles(path, searchPattern, searchOption);

            return files;
        }

        /// <summary>
        /// Loading assemblies
        /// </summary>
        /// <param name="files">The list of files that need to load</param>
        /// <exception cref="ArgumentNullException">Invalid Path</exception>
        /// <returns>All assemblies in the provided list</returns>
        public static async Task<List<Assembly>> LoadAssembliesAsync(this IEnumerable<string> files)
        {
            if (files == null)
                throw new ArgumentNullException(nameof(files));

            if (!files.Any())
                return new List<Assembly>();

            return await Task.Run(() =>
            {
                var found = new ConcurrentBag<Assembly>();

                foreach (var file in files)
                    found.Add(Assembly.LoadFrom(file));

                return found.ToList();
            });
        }
    }
}
