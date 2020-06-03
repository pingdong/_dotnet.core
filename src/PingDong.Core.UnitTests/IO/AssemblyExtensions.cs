using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PingDong.IO;
using Xunit;

namespace PingDong.Linq
{
    public class AssemblyExtensionsTests
    {
        [Fact]
        public void Filter_ShouldThrow_ArgumentNullException_When_PathIsNullOrEmpty()
        {
            string path = null;
            Assert.Throws<ArgumentNullException>(() => path.Filter());
            
            path = string.Empty;
            Assert.Throws<ArgumentNullException>(() => path.Filter());

            path = " ";
            Assert.Throws<ArgumentNullException>(() => path.Filter());
        }

        [Fact]
        public void LoadAssembly_ShouldThrow_ArgumentNullException_When_PathIsNullOrEmpty()
        {
            List<string> files = null;
            Assert.ThrowsAsync<ArgumentNullException>(async () => await files.LoadAssembliesAsync());
        }

        [Fact]
        public async Task LoadAssembly_ShouldReturn_Empty_When_FilesAreEmpty()
        {
            var files = new List<string>();
            var list = await files.LoadAssembliesAsync();
            Assert.Empty(list);
        }

        [Fact]
        public void Filter_ShouldReturn_SpecifiedFiles_When_HasSearchPattern()
        {
            var path = Directory.GetCurrentDirectory();

            var list = path.Filter("PingDong.*.dll");

            Assert.Equal(2, list.Count());
        }

        [Fact]
        public async Task LoadAssembly_ShouldReturn_SpecifiedAssemblies_When_HasFiles()
        {
            var path = Directory.GetCurrentDirectory();

            var list = await path.Filter("PingDong.*.dll").LoadAssembliesAsync();

            Assert.Equal(2, list.Count);
        }
    }
}