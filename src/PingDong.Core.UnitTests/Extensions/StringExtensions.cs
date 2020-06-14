using System;
using Xunit;

namespace PingDong
{
    public class StringExtensionsTests
    {
        [Fact]
        public void FirstCharToUpper()
        {
            var value = "test";

            var st1 = value.FirstCharToUpper();
            Assert.Equal("Test", st1);

            var st2 = st1.FirstCharToUpper();
            Assert.Equal("Test", st2);
        }

        [Fact]
        public void FirstCharToUpper_IfStringIsNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => ((string)null).FirstCharToUpper());
            Assert.Throws<ArgumentNullException>(() => "".FirstCharToUpper());
            Assert.Throws<ArgumentNullException>(() => " ".FirstCharToUpper());
        }

        [Fact]
        public void FirstCharToLower()
        {
            var value = "Test";

            var st1 = value.FirstCharToLower();
            Assert.Equal("test", st1);

            var st2 = st1.FirstCharToLower();
            Assert.Equal("test", st2);
        }

        [Fact]
        public void FirstCharToLower_IfStringIsNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => ((string)null).FirstCharToLower());
            Assert.Throws<ArgumentNullException>(() => "".FirstCharToLower());
            Assert.Throws<ArgumentNullException>(() => " ".FirstCharToLower());
        }
    }
}
