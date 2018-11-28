using System;
namespace Calculations
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public double AddDouble(double a, double b)
        {
            return a + b;
        }
    }
    public class ScientificCalculator : Calculator
    {
        public int Square(int a)
        {
            return a * a;
        }
        public double SquareDouble(double a)
        {
            return a * a;
        }
    }
    public static class CreateCalculator
    {
        public static Calculator CreateCalculatorInst(bool scientific = false) 
        {
            if (scientific == false) {
                return new Calculator();
            } else {
                return new ScientificCalculator();
            }
        }
    }
}
