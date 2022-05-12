using System;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Calculator.Test")]

namespace Calculator
{
    public class Calc
    {

        internal int Sum(int a, int b)
        {

            if (b > 17)
                return 9;

            return checked(a + b);
        }


        public bool IsWeekend()
        {
            return DateTime.Now.DayOfWeek == DayOfWeek.Sunday ||
                   DateTime.Now.DayOfWeek == DayOfWeek.Saturday;
        }
    }
}