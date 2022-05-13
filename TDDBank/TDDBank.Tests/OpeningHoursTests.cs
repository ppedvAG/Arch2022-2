using System;
using Xunit;

namespace TDDBank.Tests
{

    public class OpeningHoursTests
    {
        [Theory]
        [InlineData(2022, 05, 9, 10, 30, true)]//mo
        [InlineData(2022, 05, 9, 10, 29, false)]//mo
        [InlineData(2022, 05, 9, 10, 31, true)] //mo
        [InlineData(2022, 05, 9, 18, 59, true)] //mo
        [InlineData(2022, 05, 9, 19, 00, false)] //mo
        [InlineData(2022, 05, 14, 10, 29, false)] //sa
        [InlineData(2022, 05, 14, 10, 30, true)] //sa
        [InlineData(2022, 05, 14, 10, 31, true)] //sa
        [InlineData(2022, 05, 14, 13, 59, true)] //sa
        [InlineData(2022, 05, 14, 14, 0, false)] //sa
        [InlineData(2022, 05, 14, 14, 1, false)] //sa
        [InlineData(2022, 05, 15, 20, 0, false)] //so
        public void OpeningHours_IsOpen(int y, int M, int d, int h, int m, bool result)
        {
            var dt = new DateTime(y, M, d, h, m, 0);
            var oh = new OpeningHours();

            Assert.Equal(result, oh.IsOpen(dt));
        }


        [Fact]
        public void OpeningHours_IsNowOpen_Can_execute()
        {
            var oh = new OpeningHours();

            var result = oh.IsNowOpen();

            Assert.Equal(result, oh.IsOpen(DateTime.Now)); //kampf den Mutanten!!!!
        }
    }
}
