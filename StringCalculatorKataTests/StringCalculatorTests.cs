using System;
using FluentAssertions;
using Xunit;
using Xunit.Extensions;

namespace StringCalculatorKata.Tests
{
    public class StringCalculatorTests
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("0", 0)]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        public void StringNumberShouldReturnInt(string number, int expectedValue)
        {
            var stringCalculator = new StringCalculator();

            int actualValue = stringCalculator.Sum(number);

            actualValue.Should().Be(expectedValue);
        }

        [Fact]
        public void OneAndTwoShouldReturn3()
        {
            var stringCalculator = new StringCalculator();

            int three = stringCalculator.Sum("1,2");

            three.Should().Be(3);
        }

        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("1\n2, 3", 6)]
        [InlineData("10,51,301", 362)]
        [InlineData("0,0,0", 0)]
        public void SeveralStringNumbersShouldReturnSummetValue(string number, int expectedValue)
        {
            var stringCalculator = new StringCalculator();

            int actualValue = stringCalculator.Sum(number);

            actualValue.Should().Be(expectedValue);
        }

        [Fact]
        public void NewLineShouldWorkAsComma()
        {
            var stringCalculator = new StringCalculator();

            int three = stringCalculator.Sum("1\n2");

            three.Should().Be(3);
        }

        [Fact]
        public void DelimiterShouldBeChangeable()
        {
            var stringCalculator = new StringCalculator();

            int three = stringCalculator.Sum("\\;\n1;2");

            three.Should().Be(3);
        }

        [Fact]
        public void NegativeValueShouldThrowException()
        {
            var stringCalculator = new StringCalculator();
            Action action = () => stringCalculator.Sum("-1");

            action.ShouldThrow<Exception>()
                                .WithMessage("Negatives not allowed*");
        }

        [Fact]
        public void NegativeValuesShouldThrowException()
        {
            var stringCalculator = new StringCalculator();
            Action action = () => stringCalculator.Sum("-1,-2,5");

            action.ShouldThrow<Exception>()
                                .WithMessage("Negatives not allowed: -1, -2");
        }

        [Fact]
        public void NumberGreaterThan1000ShouldBeIgnored()
        {
            var stringCalculator = new StringCalculator();

            int five = stringCalculator.Sum("1000,5");

            five.Should().Be(5);
        }

        [Theory]
        [InlineData("\\[xxxxxxx]\n1xxxxxxx2xxxxxxx3", 6)]
        [InlineData("\\[%%]\n1%%2%%3", 6)]
        [InlineData("\\[!!!!]\n1!!!!2!!!!3", 6)]
        public void DelimiterOfAnyLengthShouldBeHandled(string number, int expectedValue)
        {
            var stringCalculator = new StringCalculator();

            int actualValue = stringCalculator.Sum(number);

            actualValue.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData("\\[***][%%%]\n1***2%%%3", 6)]
        [InlineData("\\[*][%]\n1*2%3", 6)]
        [InlineData("\\[!!!!][xxxxxxx]\n1xxxxxxx2!!!!3", 6)]
        public void MultipleNewDelimitersShouldBeHandled(string number, int expectedValue)
        {
            var stringCalculator = new StringCalculator();

            int actualValue = stringCalculator.Sum(number);

            actualValue.Should().Be(expectedValue);
        }

    }
}
