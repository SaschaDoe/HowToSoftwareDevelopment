using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfDigitsKata
{
    public static class SumOfDigitsExtensionFunctional
    {
        public static IEnumerable<int> ParseStringToIntSequence(int input)
        {
            return input.ToString().Select(t => int.Parse(t.ToString()));
        }

        public static int NumberOfDigits(this int number)
        {
            return (int) Math.Floor(Math.Log10(number) + 1);
        }

        public static int SumOfDigitsFunctional(this int digits)
        {
            return digits.NumberOfDigits() == 1
                ? digits
                : SumOfDigitsSequence(digits).ToList().Last().sum;
        }

        private static IEnumerable<(int numberOfDigits,int sum )> SumOfDigitsSequence(int digits)
        {
            var numberOfDigits = digits.ToString().Length;
            var sum = digits;
            while (numberOfDigits > 1)
            {
                numberOfDigits = SumOfDigitsStep(ref sum);
                yield return new (numberOfDigits, sum);
            }

            yield return (numberOfDigits, sum);
        }

        private static int SumOfDigitsStep(ref int sum)
        {
            int numberOfDigits;
            sum = ParseStringToIntSequence(sum).Sum();
            numberOfDigits = NumberOfDigits(sum);
            return numberOfDigits;
        }
    }
}