using System;
using System.IO;
using Xunit;

namespace PingDong.Reflection
{
    public class AssemblyExtensionsTests
    {
        [Fact]
        public void Load_ThrowArgumentNullException_WhenPathIsNullOrEmptyOrInvalid()
        {
            string path = null;
            Assert.Throws<ArgumentNullException>(() => AssemblyExtensions.Load(path));
            
            path = string.Empty;
            Assert.Throws<ArgumentNullException>(() => AssemblyExtensions.Load(path));

            path = " ";
            Assert.Throws<ArgumentNullException>(() => AssemblyExtensions.Load(path));

            path = Path.Combine(Directory.GetCurrentDirectory(), Guid.NewGuid().ToString());
            Assert.Throws<ArgumentNullException>(() => AssemblyExtensions.Load(path));
        }

        [Fact]
        public void Load_ShouldReturnAll_WhenNoFilter()
        {
            var path = Directory.GetCurrentDirectory();

            var list = AssemblyExtensions.Load(path);

            Assert.Equal(Directory.GetFiles(path, "*.dll").Length, list.Count);
        }

        [Fact]
        public void Load_ThrowException_WhenIncludeNonExecutable()
        {
            var path = Directory.GetCurrentDirectory();

            Assert.Throws<BadImageFormatException>(() => AssemblyExtensions.Load(path, "*.pdb"));
        }

        [Fact]
        public void Load_ShouldReturnEmpty_WhenFilterNotCover()
        {
            var path = Directory.GetCurrentDirectory();
            var filter = Guid.NewGuid().ToString();

            var list = AssemblyExtensions.Load(path, filter);

            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void Filter_ShouldReturn_SpecifiedFiles_When_HasSearchPattern()
        {
            var path = Directory.GetCurrentDirectory();
            var filter = "PingDong.*.dll";

            var list = AssemblyExtensions.Load(path, filter);

            Assert.Equal(2, list.Count);
        }
    }
}