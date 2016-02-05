using System.Collections.Generic;
using System.Linq;

namespace RomanNumeralKata
{
    public class RomanNumeralConverter
    {
        private IDictionary<int, string> baseValues = new Dictionary<int, string>
        {
            [0] = "",
            [1] = "I",
            [5] = "V",
            [10] = "X",
            [50] = "L",
            [100] = "C",
            [500] = "D",
            [1000] = "M"
        };

        public string Convert(int integerToConvert)
        {
            string latinBaseValue;
            if (baseValues.TryGetValue(integerToConvert, out latinBaseValue))
            {
                return latinBaseValue;
            }

            foreach (var baseValue in baseValues.Reverse())
            {
                int delta = baseValue.Key - integerToConvert;
                if (delta >= 0)
                {
                    return baseValue.Value + Convert(delta);
                }

                if (baseValues.TryGetValue(-delta, out latinBaseValue))
                {
                    return latinBaseValue + Convert(integerToConvert - delta);
                }
            }

            return "";
        }
    }
}
