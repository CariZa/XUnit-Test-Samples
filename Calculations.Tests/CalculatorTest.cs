using System;
using Xunit;

namespace Calculations.Tests
{
    public class CalculatorTest
    {
        [Fact]
        [Trait("Category", "Calculator")]
        public void Add_GivenTwoIntValues_ReturnsInt() 
        {
            Calculator calculator = new Calculator();
            int result = calculator.Add(1, 2);
            Assert.Equal(3, result);
        }

        [Fact]
        [Trait("Category", "Calculator")]
        public void Add_GivenTwoDoubleValues_ReturnsDouble()
        {
            Calculator calculator = new Calculator();
            double result = calculator.AddDouble(1.1, 2.2);
            Assert.Equal(3.3, result, 1);
        }
        [Fact]
        [Trait("Category", "ScientificCalculator")]
        public void CreateCalculatorInst()
        {
            var calc = CreateCalculator.CreateCalculatorInst(true);
            var instCalc = Assert.IsType<ScientificCalculator>(calc);
            Assert.Equal(4, instCalc.Square(2));
        }

    }
}
