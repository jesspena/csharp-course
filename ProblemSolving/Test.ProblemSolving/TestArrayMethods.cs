using Xunit;
using ProblemSolving.Recursion;

namespace Test.ProblemSolving.Recursion
{
    public class TestArrayMethods
    {
        [Fact]
        public void Sum_ShouldReturnCorrectSum_WhenArrayIsNotEmpty()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            var result = ArrayMethods.Sum(numbers);

            Assert.Equal(15, result);
        }

        [Fact]
        public void Sum_ShouldReturnZero_WhenArrayIsEmpty()
        {
            var numbers = new int[0];
            var result = ArrayMethods.Sum(numbers);

            Assert.Equal(0, result);
        }

        [Fact]
        public void Sum_ShouldWork_WithNegativeNumbers()
        {
            var numbers = new[] { -1, -2, -3, 4 };
            var result = ArrayMethods.Sum(numbers);

            Assert.Equal(-2, result); // (-1 -2 -3 + 4 = -2)
        }
    }
}
