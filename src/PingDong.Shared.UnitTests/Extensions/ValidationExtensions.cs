using System;
using PingDong.Validation;
using Xunit;

namespace PingDong.Shared
{
    public class ValidationExtensions
    {
        [Fact]
        public void ThrowIfMissing()
        {
            object target = null;
            Assert.Throws<DataNotExistedException>(() => target.ThrowIfMissing());

            target = new object();
            target.ThrowIfMissing();
        }
        
        [Fact]
        public void ThrowIfExisting()
        {
            object target = null;
            target.ThrowIfExisting();
            
            target = new object();
            Assert.Throws<DataExistedException>(() => target.ThrowIfExisting());
        }

        [Fact]
        public void ThrowIfNullOrDefault()
        {
            object target = null;
            Assert.Throws<InvalidParameterException>(() => target.ThrowIfNullOrDefault("parameter"));
            
            Assert.Throws<InvalidParameterException>(() => 0D.ThrowIfNullOrDefault("parameter"));

            Assert.Throws<InvalidParameterException>(() => Guid.Empty.ThrowIfNullOrDefault("parameter"));
            
            Assert.Throws<InvalidParameterException>(() => string.Empty.ThrowIfNullOrDefault("parameter"));
            Assert.Throws<InvalidParameterException>(() => " ".ThrowIfNullOrDefault("parameter"));
        }

        [Fact]
        public void EnsureNotNullOrDefault()
        {
            object target = null;
            Assert.Throws<ArgumentNullException>(() => target.EnsureNotNullOrDefault("parameter"));
            
            Assert.Throws<ArgumentNullException>(() => 0D.EnsureNotNullOrDefault("parameter"));

            Assert.Throws<ArgumentNullException>(() => Guid.Empty.EnsureNotNullOrDefault("parameter"));
            
            Assert.Throws<ArgumentNullException>(() => string.Empty.EnsureNotNullOrDefault("parameter"));
            Assert.Throws<ArgumentNullException>(() => " ".EnsureNotNullOrDefault("parameter"));
        }

        [Fact]
        public void ThrowIfUnableToConvertToGuid()
        {
            Assert.Throws<InvalidParameterException>(() => string.Empty.ThrowIfUnableToConvertToGuid("parameter"));
            Assert.Throws<InvalidParameterException>(() => " ".ThrowIfUnableToConvertToGuid("parameter"));

            
            Assert.Throws<InvalidParameterException>(() => "ABC".ThrowIfUnableToConvertToGuid("parameter"));

            Assert.Throws<InvalidParameterException>(() => Guid.Empty.ToString().ThrowIfUnableToConvertToGuid("parameter"));

            Guid.NewGuid().ToString().ThrowIfUnableToConvertToGuid("parameter");
            
        }
    }
}
