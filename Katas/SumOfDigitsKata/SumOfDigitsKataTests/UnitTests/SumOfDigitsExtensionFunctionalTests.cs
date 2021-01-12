using SumOfDigitsKata;
using Xunit;

namespace SumOfDigitsKataTests
{
    
    public class SumOfDigitsExtensionFunctionalTests
    {
        #region SumOfDigitsFunctional

        [Fact]
        [Trait("Category", "Unit")]
        public void SumOfDigitsFunctional_Zero()
        {
            Assert.Equal(0,0.SumOfDigitsFunctional());
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void SumOfDigitsFunctional_One_When_One()
        {
            Assert.Equal(1,1.SumOfDigitsFunctional());
        }
        
        [Fact]
        [Trait("Category", "Unit")]
        public void SumOfDigitsFunctional_One_When_Ten()
        {
            Assert.Equal(1,10.SumOfDigitsFunctional());
        }
        
        [Fact]
        [Trait("Category", "Unit")]
        public void SumOfDigitsFunctional_Two_When_Eleven()
        {
            Assert.Equal(2,11.SumOfDigitsFunctional());
        }
        
        [Fact]
        [Trait("Category", "Unit")]
        public void SumOfDigitsFunctional_Three_When_111()
        {
            Assert.Equal(3,111.SumOfDigitsFunctional());
        }
        
        [Fact]
        [Trait("Category", "Unit")]
        public void SumOfDigitsFunctional_8_When_44()
        {
            Assert.Equal(8,888884.SumOfDigitsFunctional());
        }

        #endregion
    }
}