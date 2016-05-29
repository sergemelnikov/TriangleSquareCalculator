using System;
using System.Collections.Generic;

namespace TriangleSquareCalc
{
    public static class RightTriangleSquareCalculator
    {
        //допустимая погрешность
        static double epsilon = 0.0001;

        /// <summary>
        /// Проверяет, выполняется ли теорема Пифагора для трех чисел, задающих длины катетов и гипотенузы
        /// Проверка проходит с точностью Epsilon
        /// </summary>
        /// <param name="cathetus1">Длина первого катета</param>
        /// <param name="cathetus2">Длина второго катета</param>
        /// <param name="hypotenuse">Длина гипотенузы</param>
        /// <returns>True, если условие теоремы выполнено, False в противном случае</returns>
        static bool checkPifagorTheorem(double cathetus1, double cathetus2, double hypotenuse)
        {
            if (Math.Abs((cathetus1 * cathetus1 + cathetus2 * cathetus2 - hypotenuse * hypotenuse)) > epsilon)
                return false;
            return true;
        }

        /// <summary>
        /// Находит площадь прямоугольного треугольника по длинам его сторон
        /// На вход ожидается массив из трех элементов, задающих длины сторон треугольника
        /// </summary>
        /// <param name="lengths">Длины сторон</param>
        /// <returns>Площадь треугольника</returns>
        public static double GetSquare(double[] lengths)
        {
            //проверка на количество сторон
            if (lengths.Length != 3)
                throw new ArgumentOutOfRangeException("Ожидалось три числа - длины сторон треугольника");

            //проверка на то, что длины положительны (вырожденный треугольник не может считаться прямоугольным)
            foreach (double l in lengths)
                if (l <= 0)
                    throw new ArgumentOutOfRangeException("Длина стороны должна быть положительным числом");

            //находим индекс гипотенузы 
            //(длина гипотенузы строго больше длин катетов)
            int hypotenuseIndex = 0;
            for (int i = 1; i < 3; ++i)
                if (lengths[i] > lengths[hypotenuseIndex])
                    hypotenuseIndex = i;
            //получаем индексы катетов
            List<int> cathetusIndexes = new List<int> { 0, 1, 2 };
            cathetusIndexes.Remove(hypotenuseIndex);

            //проверяем, выолняется ли теорема Пифагора
            if (!checkPifagorTheorem(lengths[cathetusIndexes[0]], lengths[cathetusIndexes[1]], lengths[hypotenuseIndex]))
                throw new ArgumentOutOfRangeException("Введенные три числа не могут быть длинами сторон прямоугольного треугольника, т.к. не выполняется теорема Пифагора");

            //все проверки пройдены, находим площадь по формуле и возвращаем ее
            return (lengths[cathetusIndexes[0]] * lengths[cathetusIndexes[1]]) / 2;

        }

        /// <summary>
        /// Находит площадь прямоугольного треугольника по длинам его сторон
        /// Принимает 3 аргумента
        /// </summary>
        /// <param name="l1">Длина стороны номер 1</param>
        /// <param name="l2">Длина стороны номер 2</param>
        /// <param name="l3">Длина стороны номер 3</param>
        /// <returns>Площадь треугольника</returns>
        public static double GetSquare(double l1, double l2, double l3)
        {
            return GetSquare(new double[] { l1, l2, l3 });
        }


    }
}
