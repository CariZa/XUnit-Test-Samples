using System;
using System.Collections.Generic;
using Xunit;

namespace Calculations.Tests
{
    public class FibonnaciFixture
    {
        public Fibonnaci fib => new Fibonnaci();
    }

    public class FibonnaciTest: IClassFixture<FibonnaciFixture>
    {
        private readonly FibonnaciFixture _fibonnaciFixture;

        public FibonnaciTest(FibonnaciFixture fibonnaciFixture) 
        {
            _fibonnaciFixture = fibonnaciFixture;
        }

        [Fact]
        public void Fibonnaci_Generates_ReturnsFibonnaciNumsList()
        {
            //Fibonnaci fib = new Fibonnaci();
            List<int> nums = _fibonnaciFixture.fib.fibonnaci;
            Assert.All(nums, n => Assert.NotEqual(0, n));

        }

        [Fact]
        public void Fibonnaci_CheckOdd_ReturnsBool()
        {
            //Fibonnaci fib = _fibonnaciFixture.fib;
            int num = 1;
            bool odd = _fibonnaciFixture.fib.IsOdd(num);
            Assert.True(odd);
        }

        [Fact]
        public void Fibonnaci_CheckEven_ReturnsBool()
        {
            int num = 200;
            bool even = _fibonnaciFixture.fib.IsEven(num);
            Assert.True(even);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(200, false)]
        public void Fibonnaci_CheckEvenOrOdd_ReturnsBool(int value, bool result)
        {
            bool odd = _fibonnaciFixture.fib.IsOdd(value);
            Assert.Equal(odd, result);
        }

        [Theory]
        [MemberData(nameof(SharedFibonnaciData.IsOddOrEvenData), MemberType = typeof(SharedFibonnaciData))]
        public void FibonnaciSharedData_CheckEvenOrOdd_ReturnsBool(int value, bool result)
        {
            bool odd = _fibonnaciFixture.fib.IsOdd(value);
            Assert.Equal(odd, result);
            //Assert.True(result);
        }
    }
}
