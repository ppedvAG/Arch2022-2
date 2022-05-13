using Microsoft.QualityTools.Testing.Fakes;
using NUnit.Framework;
using System;

namespace Calculator.Test
{
    [TestFixture]
    public class CalcTests
    {
        [Test]
        public void Sum_2_and_3_results_5()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            var result = calc.Sum(2, 3);

            //Assert
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Sum_0_and_0_results_0()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            var result = calc.Sum(0, 0);

            //Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(1, 2, 3)]
        [TestCase(100, 16, 116)]
        [TestCase(100, -20, 80)]
        [TestCase(-100, -20, -120)]
        public void Sum_With_Cases(int a, int b, int exp)
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            var result = calc.Sum(a, b);

            //Assert
            Assert.AreEqual(exp, result);
        }

        [Test]
        public void Sum_MAX_and_1_throws()
        {
            Calc calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(int.MaxValue, 1));
            Assert.Throws<OverflowException>(() => calc.Sum(int.MinValue, -1));

        }


        [Test]
        public void Sum_b_more_than_17_results_9()
        {
            //Arrange
            Calc calc = new Calc();

            Assert.AreEqual(16, calc.Sum(0, 16));
            Assert.AreEqual(17, calc.Sum(0, 17));
            Assert.AreEqual(9, calc.Sum(0, 18));
        }

        [Test]
        public void IsWeekend()
        {
            //Arrange
            Calc calc = new Calc();


            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime (2022, 5, 9);//mo
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime (2022, 5, 10);//di
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime (2022, 5, 11);//mi
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime (2022, 5, 12);//do
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2022, 5, 13);//fr
                Assert.IsFalse(calc.IsWeekend());

                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2022, 5, 14);//sa
                Assert.IsTrue(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2022, 5, 15);//so
                Assert.IsTrue(calc.IsWeekend());

            }
        }

    }
}