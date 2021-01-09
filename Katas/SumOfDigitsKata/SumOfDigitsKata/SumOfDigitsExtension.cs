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

       
    }
}