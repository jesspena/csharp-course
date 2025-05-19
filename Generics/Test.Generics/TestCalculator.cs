using Generics;

namespace Test.Generics
{
    public class TestCalculator
    {
        // TODO: Add tests
        private readonly Calculator<int> _intCalc = new Calculator<int>();
        private readonly Calculator<double> _doubleCalc = new Calculator<double>();

        [Fact]
        public void Add_Int_ShouldReturnCorrectResult()
        {
            int result = _intCalc.Add(2, 3);
            Assert.Equal(5, result);
        }

        [Fact]
        public void Substract_Int_ShouldReturnCorrectResult()
        {
            int result = _intCalc.Substract(10, 4);
            Assert.Equal(6, result);
        }

        [Fact]
        public void Multiply_Int_ShouldReturnCorrectResult()
        {
            int result = _intCalc.Multiply(2, 5);
            Assert.Equal(10, result);
        }

        [Fact]
        public void Divide_Int_ShouldReturnCorrectResult()
        {
            int result = _intCalc.Divide(10, 2);
            Assert.Equal(5, result);
        }

        [Fact]
        public void Add_Double_ShouldReturnCorrectResult()
        {
            double result = _doubleCalc.Add(2.5, 3.2);
            Assert.Equal(5.7, result, 1);
        }
    }
}
