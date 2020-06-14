using System;
using System.Globalization;
using Xunit;

namespace PingDong
{
    public class DateTimeExtensionsTests
    {
        public class ToTimestamp
        {
            [Fact]
            public void To()
            {
                var datetime = new DateTime(2014, 5, 20, 15, 38, 00, 02, DateTimeKind.Utc);

                Assert.Equal(1400600280002, datetime.ToTimestampWithMillisecond());
                Assert.Equal(1400600280, datetime.ToTimestampWithSecond());
            }

            [Fact]
            public void To_InvalidUtc()
            {
                var datetime = new DateTime(1814, 5, 20, 15, 38, 00, 02);

                Assert.Throws<ArgumentOutOfRangeException>(() => datetime.ToTimestampWithMillisecond());
                Assert.Throws<ArgumentOutOfRangeException>(() => datetime.ToTimestampWithSecond());
            }
        }

        public class FromTimestamp
        {
            [Fact]
            public void From()
            {
                var datetime = new DateTime(2014, 5, 20, 15, 38, 00, 02, DateTimeKind.Utc);
                Assert.Equal(datetime, DateTimeExtensions.FromTimestampWithMillisecond(1400600280002));

                datetime = new DateTime(2014, 5, 20, 15, 38, 00);
                Assert.Equal(datetime, DateTimeExtensions.FromTimestampWithSecond(1400600280));
            }

            [Fact]
            public void From_Invalid()
            {
                Assert.Throws<ArgumentException>(() => DateTimeExtensions.FromTimestampWithMillisecond(-1));
                Assert.Throws<ArgumentException>(() => DateTimeExtensions.FromTimestampWithSecond(-1));
            }
        }

        public class EnsureUtc
        {
            [Fact]
            public void Invalid_Local()
            {
                var datetime = new DateTime(1977, 4, 22, 0, 0, 0, DateTimeKind.Local);

                Assert.Throws<ArgumentException>(() => datetime.EnsureUtc());
            }

            [Fact]
            public void Invalid_Unspecified()
            {
                var datetime = new DateTime(1977, 4, 22, 0, 0, 0, DateTimeKind.Unspecified);

                Assert.Throws<ArgumentException>(() => datetime.EnsureUtc());
            }

            [Fact]
            public void Valid()
            {
                var datetime = new DateTime(1977, 4, 22, 0, 0, 0, DateTimeKind.Utc);

                datetime.EnsureUtc();
            }
        }

        public class ToLocalDateTime
        {
            [Fact]
            public void EmptyTimeZone()
            {
                Assert.Throws<ArgumentNullException>(() => DateTime.Now.ToLocalDateTime((TimeZoneInfo)null));

                Assert.Throws<ArgumentNullException>(() => DateTime.Now.ToLocalDateTime((string)null));
                Assert.Throws<ArgumentNullException>(() => DateTime.Now.ToLocalDateTime(string.Empty));
                Assert.Throws<ArgumentNullException>(() => DateTime.Now.ToLocalDateTime(" "));
            }

            [Fact]
            public void Utc()
            {
                var now = DateTime.Now;
                var timezone = TimeZoneInfo.Local;

                var local = now.ToUniversalTime().ToLocalDateTime(timezone.Id);
                Assert.Equal(now, local);

                local = now.ToUniversalTime().ToLocalDateTime(timezone);
                Assert.Equal(now, local);
            }

            [Fact]
            public void Local()
            {
                var now = DateTime.Now;
                var timezone = TimeZoneInfo.Local;

                var local = now.ToLocalDateTime(timezone.Id);
                Assert.Equal(now, local);

                local = now.ToLocalDateTime(timezone);
                Assert.Equal(now, local);
            }
        }

        public class ToMidnight
        {
            [Fact]
            public void Utc()
            {
                var now = DateTime.UtcNow;

                var midnight = now.ToMidnight();

                Assert.Equal(now.Kind, midnight.Kind);
                Assert.Equal(now.Year, midnight.Year);
                Assert.Equal(now.Month, midnight.Month);
                Assert.Equal(now.Day, midnight.Day);
                Assert.Equal(0, midnight.Hour);
                Assert.Equal(0, midnight.Minute);
                Assert.Equal(0, midnight.Second);
                Assert.Equal(0, midnight.Millisecond);
            }

            [Fact]
            public void Local()
            {
                var now = DateTime.Now;

                var midnight = now.ToMidnight();

                Assert.Equal(now.Kind, midnight.Kind);
                Assert.Equal(now.Year, midnight.Year);
                Assert.Equal(now.Month, midnight.Month);
                Assert.Equal(now.Day, midnight.Day);
                Assert.Equal(0, midnight.Hour);
                Assert.Equal(0, midnight.Minute);
                Assert.Equal(0, midnight.Second);
                Assert.Equal(0, midnight.Millisecond);
            }
        }

        public class ToUtcString
        {
            [Fact]
            public void LocalTime()
            {
                Assert.Throws<ArgumentException>(() => DateTime.Now.ToUtcString());
            }

            [Fact]
            public void Utc()
            {
                var time = DateTime.UtcNow;

                Assert.Equal(time.ToString("o", CultureInfo.InvariantCulture), time.ToUtcString());
            }
        }

        public class FromUtcString
        {
            [Fact]
            public void EmptyString()
            {
                Assert.Throws<ArgumentNullException>(() => DateTimeExtensions.FromUtcString((string)null));
                Assert.Throws<ArgumentNullException>(() => DateTimeExtensions.FromUtcString(string.Empty));
                Assert.Throws<ArgumentNullException>(() => DateTimeExtensions.FromUtcString(" "));
            }

            [Fact]
            public void Invalid()
            {
                Assert.Throws<ArgumentException>(() => DateTimeExtensions.FromUtcString("ABC"));
            }

            [Fact]
            public void Valid()
            {
                var time = DateTime.UtcNow;
                var timeString = time.ToString("o", CultureInfo.InvariantCulture);

                Assert.Equal(time, DateTimeExtensions.FromUtcString(timeString));
            }
        }

        public class GetCurrentTime
        {
            [Fact]
            public void EmptyTimeZone()
            {
                Assert.Throws<ArgumentNullException>(() => DateTimeExtensions.GetCurrentTime((TimeZoneInfo)null));

                Assert.Throws<ArgumentNullException>(() => DateTimeExtensions.GetCurrentTime((string)null));
                Assert.Throws<ArgumentNullException>(() => DateTimeExtensions.GetCurrentTime(string.Empty));
                Assert.Throws<ArgumentNullException>(() => DateTimeExtensions.GetCurrentTime(" "));
            }

            [Fact]
            public void WrongTimeZone()
            {
                Assert.Throws<TimeZoneNotFoundException>(() => DateTimeExtensions.GetCurrentTime("ABC"));
            }

            [Fact]
            public void Valid_Id()
            {
                var utc = DateTime.UtcNow;
                var nzst = DateTimeExtensions.GetCurrentTime(TimeZoneInfo.Local.Id);

                Assert.True(nzst.ToUniversalTime().ToTimestampWithSecond() - utc.ToTimestampWithSecond() < 1);
            }

            [Fact]
            public void Valid()
            {
                var utc = DateTime.UtcNow;
                var nzst = DateTimeExtensions.GetCurrentTime(TimeZoneInfo.Local);

                Assert.True(nzst.ToUniversalTime().ToTimestampWithSecond() - utc.ToTimestampWithSecond() < 10);
            }
        }
    }
}
