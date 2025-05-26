using Xunit;
using ProblemSolving.Recursion;

namespace Test.ProblemSolving.Recursion
{
    public class TestFibonacci
    {
        [Fact]
        public void Fibonacci_ShouldReturnCorrectData()
        {
            Assert.Equal(0, Fibonacci.GetFibonacci(0));
            Assert.Equal(1, Fibonacci.GetFibonacci(1));
            Assert.Equal(1, Fibonacci.GetFibonacci(2));
            Assert.Equal(2, Fibonacci.GetFibonacci(3));
            Assert.Equal(3, Fibonacci.GetFibonacci(4));
            Assert.Equal(5, Fibonacci.GetFibonacci(5));
            Assert.Equal(8, Fibonacci.GetFibonacci(6));
            Assert.Equal(13, Fibonacci.GetFibonacci(7));
        }
    }
}
