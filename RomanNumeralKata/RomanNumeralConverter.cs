using System.Collections.Generic;
using System.Linq;

namespace RomanNumeralKata
{
    public class RomanNumeralConverter
    {
        readonly IDictionary<int, string> baseValues = new Dictionary<int, string>
        {
            [0] = "",
            [1] = "I",
            [5] = "V",
            [9] = "IX",
            [10] = "X",
            [50] = "L",
            [90] = "XC",
            [100] = "C",
            [500] = "D",
            [900] = "CM",
            [1000] = "M"
        };

        readonly LinkedList<int> reprensentableNumbers = new LinkedList<int>(new[] { 1, 5, 10, 50, 100, 500, 1000 });

        public string Convert(int integerToConvert)
        {
            string latinBaseValue;
            if (baseValues.TryGetValue(integerToConvert, out latinBaseValue))
            {
                return latinBaseValue;
            }

            if (integerToConvert > reprensentableNumbers.Last.Value)
            {
                return Convert(reprensentableNumbers.Last.Value) + Convert(integerToConvert - reprensentableNumbers.Last.Value);
            }

            var previous = GetPreviousPreviousReprensentableNumber(integerToConvert);
            if (integerToConvert < previous * 4)
            {
                return Convert(previous) + Convert(integerToConvert - previous);
            }

            var next = GetNextReprensentableNumber(integerToConvert);
            return Convert(previous) + Convert(next) + Convert(integerToConvert - next + previous);
        }

        private int GetPreviousPreviousReprensentableNumber(int key)
        {
            var next = GetNextReprensentableNumber(key);
            return reprensentableNumbers.Find(next).Previous.Value;
        }

        private int GetNextReprensentableNumber(int key)
        {
            return reprensentableNumbers.First(node => node > key);
        }
    }
}
