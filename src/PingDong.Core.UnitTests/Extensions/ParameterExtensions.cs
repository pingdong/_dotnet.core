using PingDong.Entity;
using System;
using System.Collections.Generic;
using Xunit;

namespace PingDong
{
    public class ParameterExtensionsTests
    {
        [Fact]
        public void EnsureNotNull()
        {
            Assert.Throws<ArgumentNullException>(() => ((object)null).EnsureNotNull());

            new object().EnsureNotNull();
        }

        [Fact]
        public void EnsureNotNullOrDefault()
        {
            Assert.Throws<ArgumentNullException>(() => ((object)null).EnsureNotNullOrDefault());

            Assert.Throws<ArgumentNullException>(() => 0D.EnsureNotNullOrDefault());

            Assert.Throws<ArgumentNullException>(() => Guid.Empty.EnsureNotNullOrDefault());

            string.Empty.EnsureNotNullOrDefault();
            " ".EnsureNotNullOrDefault();
        }

        [Fact]
        public void EnsureNotNullOrEmptyCollection()
        {
            Assert.Throws<ArgumentNullException>(() => ((IEnumerable<object>)null).EnsureNotNullOrEmptyCollection());
            Assert.Throws<ArgumentNullException>(() => new List<string>().EnsureNotNullOrEmptyCollection());
        }

        [Fact]
        public void EnsureNotNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => ((object)null).EnsureNotNullOrEmpty());

            Assert.Throws<ArgumentNullException>(() => 0D.EnsureNotNullOrEmpty());

            Assert.Throws<ArgumentNullException>(() => Guid.Empty.EnsureNotNullOrEmpty());

            Assert.Throws<ArgumentNullException>(() => string.Empty.EnsureNotNullOrEmpty());
            " ".EnsureNotNullOrDefault();
        }

        [Fact]
        public void EnsureNotNullOrWhitespace()
        {
            Assert.Throws<ArgumentNullException>(() => ((string)null).EnsureNotNullOrWhitespace());
            Assert.Throws<ArgumentNullException>(() => string.Empty.EnsureNotNullOrWhitespace());
            Assert.Throws<ArgumentNullException>(() => " ".EnsureNotNullOrWhitespace());
        }

        public class EnsureNotNullAndValidated
        {
            public class ValidClass : IValidate
            {
                public bool IsValidated()
                {
                    return true;
                }
            }

            public class InvalidClass : IValidate
            {
                public bool IsValidated()
                {
                    return false;
                }
            }

            [Fact]
            public void Null()
            {
                Assert.Throws<ArgumentNullException>(() => ((ValidClass)null).EnsureNotNullAndValidated());
            }

            [Fact]
            public void Invalid()
            {
                Assert.Throws<ArgumentException>(() => new InvalidClass().EnsureNotNullAndValidated());
            }

            [Fact]
            public void Valid()
            {
                new ValidClass().EnsureNotNullAndValidated();
            }
        }

        public class ToGuid
        {
            [Fact]
            public void Null()
            {
                Assert.Throws<ArgumentNullException>(() => ((string)null).ToGuid());
                Assert.Throws<ArgumentNullException>(() => string.Empty.ToGuid());
                Assert.Throws<ArgumentNullException>(() => " ".ToGuid());
            }

            [Fact]
            public void InvalidString()
            {
                Assert.Throws<ArgumentException>(() => "ABC".ToGuid());
            }

            [Fact]
            public void ValidString()
            {
                var guid = Guid.NewGuid();

                Assert.Equal(guid, guid.ToString().ToGuid());
            }
        }
    }
}
