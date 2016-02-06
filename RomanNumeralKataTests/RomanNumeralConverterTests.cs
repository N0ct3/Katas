using FluentAssertions;
using Xunit;

namespace RomanNumeralKata.Tests
{
    public class RomanNumeralConverterTests
    {
        [Fact]
        public void One_Should_Return_I()
        {
            var converter = new RomanNumeralConverter();

            var one = converter.Convert(1);

            one.Should().Be("I");
        }

        [Fact]
        public void Five_Should_Return_V()
        {
            var converter = new RomanNumeralConverter();

            var five = converter.Convert(5);

            five.Should().Be("V");
        }

        [Fact]
        public void Ten_Should_Return_X()
        {
            var converter = new RomanNumeralConverter();

            var ten = converter.Convert(10);

            ten.Should().Be("X");
        }

        [Fact]
        public void Two_Should_Return_II()
        {
            var converter = new RomanNumeralConverter();

            var two = converter.Convert(2);

            two.Should().Be("II");
        }

        [Fact]
        public void Three_Should_Return_III()
        {
            var converter = new RomanNumeralConverter();

            var three = converter.Convert(3);

            three.Should().Be("III");
        }

        [Fact]
        public void Four_Should_Return_IV()
        {
            var converter = new RomanNumeralConverter();

            var four = converter.Convert(4);

            four.Should().Be("IV");
        }

        [Theory]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(8, "VIII")]
        [InlineData(9, "IX")]
        [InlineData(11, "XI")]
        [InlineData(12, "XII")]
        [InlineData(15, "XV")]
        [InlineData(14, "XIV")]
        [InlineData(16, "XVI")]
        [InlineData(19, "XIX")]
        [InlineData(20, "XX")]
        [InlineData(21, "XXI")]
        [InlineData(21, "XXI")]
        [InlineData(39, "XXXIX")]
        [InlineData(40, "XL")]
        [InlineData(44, "XLIV")]
        [InlineData(49, "XLIX")]
        [InlineData(666, "DCLXVI")]
        [InlineData(707, "DCCVII")]
        [InlineData(890, "DCCCXC")]
        [InlineData(1500, "MD")]
        [InlineData(1515, "MDXV")]
        [InlineData(4888, "MMMMDCCCLXXXVIII")]
        public void Int_Should_Return_String(int numberToConvert, string expectedResult)
        {
            var converter = new RomanNumeralConverter();

            var actual = converter.Convert(numberToConvert);

            actual.Should().Be(expectedResult);
        }
    }
}
