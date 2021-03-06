using SumOfDigitsKata;
using Xunit;

namespace SumOfDigitsKataTests
{
    public class SumOfDigitsExtensionTests
    {
        #region SumOfDigits

        [Fact]
        [Trait("Category", "Unit")]
        public void Zero()
        {
            Assert.Equal(0,0.SumOfDigits());
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void One_When_One()
        {
            Assert.Equal(1,1.SumOfDigits());
        }
        
        [Fact]
        [Trait("Category", "Unit")]
        public void One_When_Ten()
        {
            Assert.Equal(1,10.SumOfDigits());
        }
        
        [Fact]
        [Trait("Category", "Unit")]
        public void Two_When_Eleven()
        {
            Assert.Equal(2,11.SumOfDigits());
        }
        
        [Fact]
        [Trait("Category", "Unit")]
        public void Three_When_111()
        {
            Assert.Equal(3,111.SumOfDigits());
        }

        #endregion
        
        

    }
}