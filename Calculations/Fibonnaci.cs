using System;
using System.Collections.Generic;

namespace Calculations
{
    public class Fibonnaci
    {
        public List<int> fibonnaci = new List<int> { 1, 1, 2, 3, 5, 8, 13 };

        public bool IsEven(int num)
        {
            return (num % 2) == 0;
        }

        public bool IsOdd(int num)
        {
            return (num % 2) == 1;
        }

    }
}
