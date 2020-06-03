using System;
using Xunit;

namespace PingDong.Shared
{
    public class StringExtensionsTest
    {
        [Fact]
        public void FirstCharToUpper()
        {
            var st = "test";

            var st1 = st.FirstCharToUpper();
            Assert.Equal("Test", st1);

            var st2 = st1.FirstCharToUpper();
            Assert.Equal("Test", st1);
        }
        [Fact]
        public void FirstCharToUpper_IfStringIsNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => "".FirstCharToUpper());
            Assert.Throws<ArgumentNullException>(() => " ".FirstCharToUpper());
        }

        [Fact]
        public void FirstCharToLower()
        {
            var st = "Test";

            var st1 = st.FirstCharToLower();
            Assert.Equal("test", st1);

            var st2 = st1.FirstCharToLower();
            Assert.Equal("test", st1);
        }
        [Fact]
        public void FirstCharToLower_IfStringIsNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => "".FirstCharToLower());
            Assert.Throws<ArgumentNullException>(() => " ".FirstCharToLower());
        }
    }
}
