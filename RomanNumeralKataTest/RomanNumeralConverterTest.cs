using Xunit;
using RomanNumeralKata;
using FluentAssertions;

namespace RomanNumeralKataTest
{
    public class RomanNumeralConverterTest
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
        public void Int_Should_Return_String(int numberToConvert, string expectedResult)
        {
            var converter = new RomanNumeralConverter();

            var actual = converter.Convert(numberToConvert);

            actual.Should().Be(expectedResult);
        }
    }
}
