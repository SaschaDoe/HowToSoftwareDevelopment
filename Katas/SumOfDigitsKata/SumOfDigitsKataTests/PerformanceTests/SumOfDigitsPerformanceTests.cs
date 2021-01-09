using System;
using System.Collections.Generic;
using System.Diagnostics;
using SumOfDigitsKata;
using Xunit;

namespace SumOfDigitsKataTests.PerformanceTests
{
    public class SumOfDigitsPerformanceTests
    {
        private const int Rounds = 1000;
        
        [Fact]
        [Trait("Category", "Performance")]
        public void SumOfDigits_ImperativeVsFunctional()
        {
            var imperativeResults = new List<int>();
            var functionalResults = new List<int>();
            var random = new Random();
            var functionalTime = 0f;
            var imperativeTime = 0f;
            for (int i = 0; i < Rounds; i++)
            {
                var randomInt = random.Next();
                var imperativeWatch = Stopwatch.StartNew();
                imperativeWatch.Start();
                for (int n = 0; n < Rounds; n++)
                {
                    imperativeResults.Add(randomInt.SumOfDigits());
                }

                imperativeWatch.Stop();
                imperativeTime += imperativeWatch.ElapsedMilliseconds;
                
                var functionalWatch = Stopwatch.StartNew();
                functionalWatch.Start();
                for (int n = 0; n < Rounds; n++)
                {
                    functionalResults.Add(randomInt.SumOfDigitsFunctional());
                }
                functionalWatch.Stop();
                functionalTime += functionalWatch.ElapsedMilliseconds;
            }
            
            Assert.Equal(imperativeResults,functionalResults);
        }

    }
}