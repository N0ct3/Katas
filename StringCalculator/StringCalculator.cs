using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Sum(string intToSum)
        {
            if (string.IsNullOrEmpty(intToSum))
            {
                return 0;
            }

            var delimiters = new List<string> { ",", "\n" };
            if (DeclaresNewDelimiter(intToSum))
            {
                UpdateDelimitersList(intToSum, delimiters);
                intToSum = GetStringWithoutNewDelimiter(intToSum);
            }

            var splitValues = intToSum.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(stringValue => int.Parse(stringValue));
            CheckForNegativeValues(splitValues);

            return splitValues.Where(value => value < 1000).Aggregate((currentSum, nextValue) => currentSum + nextValue);
        }

        private bool DeclaresNewDelimiter(string value)
        {
            return value.StartsWith(@"\", StringComparison.Ordinal);
        }

        private void CheckForNegativeValues(IEnumerable<int> splitValues)
        {
            var negativeValues = splitValues.Where(value => value < 0).ToList();
            if (negativeValues.Any())
            {
                string preparedString = string.Empty;
                negativeValues.ForEach(currentValue => preparedString += preparedString.Any() ? (", " + currentValue.ToString()) : currentValue.ToString());
                throw new Exception(string.Format("Negatives not allowed: {0}", preparedString));
            }
        }

        private string GetStringWithoutNewDelimiter(string intToSum)
        {
            return intToSum.Substring(intToSum.IndexOf('\n') + 1);
        }

        private void UpdateDelimitersList(string intToSum, List<string> delimiters)
        {
            if (intToSum.Contains("["))
            {
                var regex = new Regex(@"(?<=\[)(.*?)(?=\])");
                var newDelimiters = regex.Matches(intToSum);
                foreach (var newDelimiter in newDelimiters)
                {
                    delimiters.Add(newDelimiter.ToString());
                }
            }
            else
            {
                delimiters.Add(intToSum[1].ToString());
            }

        }
    }
}
