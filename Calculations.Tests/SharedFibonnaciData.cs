using System;
using System.Collections.Generic;

namespace Calculations.Tests
{
    public static class SharedFibonnaciData
    {
        public static IEnumerable<object[]> IsOddOrEvenData {
            get {
                yield return new object[] { 1, true };
                yield return new object[] { 200, false };
            }
        }
    }
}
