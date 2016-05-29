using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TriangleSquareCalc.Tests
{
    [TestClass]
    //тесты для класса SquareCalculator
    public class UnitTestsForSquareCalculator
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        //проверяет выдачу исключения в случае поступления больее трех аргументов
        public void TestMethodTooManyArguments()
        {
            RightTriangleSquareCalculator.GetSquare(new double[] { 1, 2, 3, 4 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        //проверяет выдачу исключения в случае поступления менее трех аргументов
        public void TestMethodTooLittleArguments()
        {
            RightTriangleSquareCalculator.GetSquare(new double[] { 1, 2 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        //проверяет выдачу исключения в случае, если один из аргументов равен нулю
        public void TestMethodZero()
        {
            RightTriangleSquareCalculator.GetSquare(0, 1, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        //проверяет выдачу исключения в случае, если один из аргументов меньше нуля
        public void TestMethodLessThenZero()
        {
            RightTriangleSquareCalculator.GetSquare(0, 1, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        //проверяет выдачу исключения, если аргументы не могут задавать длины сторон прямоугольного треугольника
        public void TestMethodNotPryamoug()
        {
            RightTriangleSquareCalculator.GetSquare(1, 2, 3);
        }


        [TestMethod]
        //пример теста, проверяющего, верно ли метод считает площадь на корректных значениях аргументов
        public void TestMethodPryamoug()
        {
            Assert.AreEqual(1, RightTriangleSquareCalculator.GetSquare(Math.Sqrt(5), 1, 2));
        }


    }
}
