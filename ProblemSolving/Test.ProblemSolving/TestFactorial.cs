using Xunit;
using ProblemSolving.Recursion;

namespace Test.ProblemSolving.Recursion
{
    public class TestFactorial
    {
        [Fact]
        public void Factorial_ShouldReturnCorrectResult_PositiveNumber()
        {
            Assert.Equal(120, Factorial.SolveFactorial(5)); 
            Assert.Equal(6, Factorial.SolveFactorial(3));   
        }

        [Fact]
        public void Factorial_ShouldReturnOne_Zero()
        {
            Assert.Equal(1, Factorial.SolveFactorial(0));
        }

        [Fact]
        public void Factorial_ShouldReturnOne_ForOne()
        {
            Assert.Equal(1, Factorial.SolveFactorial(1));
        }

        [Fact]
        public void Factorial_ShouldThrowException_ForNegativeNumber()
        {
            Assert.Throws<ArgumentException>(() => Factorial.SolveFactorial(-3));
        }
    }
}
