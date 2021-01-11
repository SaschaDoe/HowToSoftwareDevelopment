using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SumOfDigitsKata
{
    public static class SumOfDigitsExtension
    {
        public static int SumOfDigits(this int digits)
        {
            var text = digits.ToString();
            var numberOfDigits = text.Length;
            var sum = digits;
            while (numberOfDigits > 1)
            {
                var numbers = new int[numberOfDigits];
                text = sum.ToString();
                for (var i = 0; i < numberOfDigits; i++)
                {
                    numbers[i] = Int32.Parse(text[i].ToString());
                }

                sum = numbers.Sum();
                var sumText = sum.ToString();
                numberOfDigits = sumText.Length;
            }
            
            return sum;
        }

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
                : SumOfDigitsSequence(digits).TakeWhile(x => x.numberOfDigits > 1).ToList().Count > 0
                    ? SumOfDigitsSequence(digits).TakeWhile(x => x.numberOfDigits > 1).ToList().Last().sum
                    : SumOfDigitsSequence(digits).Take(1).ToList().Last().sum;
        }

        private static IEnumerable<(int numberOfDigits,int sum )> SumOfDigitsSequence(int digits)
        {
            var sum = digits;
            while (true)
            {
                var numberOfDigits = SumOfDigitsStep(ref sum);
                yield return new (numberOfDigits, sum);
            }
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