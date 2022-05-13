using System;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Calculator.Test")]

namespace Calculator
{
    public class Calc
    {

        /// <summary>Sums the specified a.</summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        internal int Sum(int a, int b)
        {

            if (b > 17)
                return 9;

            return checked(a + b);
        }


        /// <summary>Determines whether this instance is weekend.</summary>
        /// <returns>
        ///   <c>true</c> if this instance is weekend; otherwise, <c>false</c>.</returns>
        public bool IsWeekend()
        {
            return DateTime.Now.DayOfWeek == DayOfWeek.Sunday ||
                   DateTime.Now.DayOfWeek == DayOfWeek.Saturday;
        }
    }
}