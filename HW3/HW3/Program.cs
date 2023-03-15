using System;
using System.Numerics;

namespace HW3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool end = false;
            while (!end)
            {
                try
                {
                    #region проверка палиндромности заданного числа любого размера
                    print("Введите число  палиндром");
                    int z = int.Parse(Console.ReadLine() ?? "");
                    print(palindromeHandMade(z) ? $"Число {z} - палиндром" : $"Число {z} - не палиндром"); // вручную математическими методами
                    print(palindrome(z) ? $"Число {z} - палиндром" : $"Число {z} - не палиндром"); // пройдясь по строке с парсингом
                    #endregion

                    #region расстояние между двумя точками в 3d пространстве
                    print($"\nРасстоянием между точками в ручную = {rangeBetweenTwoVectorsHandMade(1, 2, 3, 3, 2, 4)}"); // рассчет расстояния между точками вручную
                    print($"Расстоянием между точками готовым решением = {rangeBetweenTwoVectors(new Vector3(1, 2, 3), new Vector3(3, 2, 4))}"); // рассчет расстояния между точками готовыми методами
                    #endregion

                    #region таблица кубов чисел от 1 до заданного
                    print($"\nЗадайте число, таблицу кубов которого вы бы хотели получить");
                    z = int.Parse(Console.ReadLine() ?? "");
                    print($"таблица кубов заданного числа {cubeToN(z)}");
                    #endregion
                    end = true;
                }
                catch (Exception ex)
                {
                    print($"\nError: \n{ex}\n");
                }
            }
        }

        /// <summary>
        /// удобство вывода без лишнего текста
        /// </summary>
        /// <param name="s">текст для вывода в консоль</param>
        static void print(string s)
        {
            Console.WriteLine(s);
        }

        /// <summary>
        /// Проверка на палиндромность заданного числа
        /// </summary>
        /// <param name="x">число, подвергаемое проверке</param>
        /// <returns>булево значение является ли заданное число палиндромом</returns>
        static bool palindromeHandMade(int x)
        {
            bool z = true;
            int temp = x;
            int count = 0;

            while (temp > 0)
            {
                temp = temp / 10;
                count++; // узнаем количество цифр в числе
            }

            for (int i = 0; i < count / 2; i++)
            {
                if ((x % Math.Pow(10, count - i) - x % Math.Pow(10, count - i - 1)) / Math.Pow(10, count - i - 1) // первое число для сравнения
                    !=
                    (x % Math.Pow(10, i + 1) - x % Math.Pow(10, i)) / Math.Pow(10, i)) // второе число для сравнения
                {
                    z = !z;
                    return z;
                }
            }
            return z;
        }

        /// <summary>
        /// Проверка на палиндромность заданного числа
        /// </summary>
        /// <param name="x">число, подвергаемое проверке</param>
        /// <returns>булево значение является ли заданное число палиндромом</returns>
        static bool palindrome(int x)
        {
            bool z = true;

            for (int i = 0; i < x.ToString().Length / 2; i++)
            {
                if (x.ToString()[i].ToString() == x.ToString()[x.ToString().Length - i - 1].ToString())
                {
                    continue;
                }
                else
                {
                    z = !z;
                }
            }
            return z;
        }

        /// <summary>
        /// Рассчет расстояния между двумя точками в трехмерном пространстве
        /// </summary>
        /// <param name="x1">координата x первой точки</param>
        /// <param name="x2">координата x второй точки</param>
        /// <param name="y1">координата y первой точки</param>
        /// <param name="y2">координата y второй точки</param>
        /// <param name="z1">координата z первой точки</param>
        /// <param name="z2">координата z второй точки</param>
        /// <returns>расстояние между двумя точками в трехмерном пространстве</returns>
        static double rangeBetweenTwoVectorsHandMade(int x1, int x2, int y1, int y2, int z1, int z2)
        {
            return Math.Sqrt((Math.Pow(x2-x1,2)) + (Math.Pow(y2 - y1, 2)) + (Math.Pow(z2 - z1, 2)));
        }

        /// <summary>
        /// Рассчет расстояния между двумя точками в трехмерном пространстве
        /// </summary>
        /// <param name="x">Первая точка</param>
        /// <param name="y">Вторая точка</param>
        /// <returns>расстояние между двумя точками в трехмерном пространстве</returns>
        static float rangeBetweenTwoVectors(Vector3 x, Vector3 y)
        {
            return Vector3.Distance(x, y);
        }

        /// <summary>
        /// создание таблицы кубов чисел от 1 до заданного
        /// </summary>
        /// <param name="n">заданное число для создания таблицы кубов от 1</param>
        /// <returns>строка с таблицей кубов чисел от 1 до заданного</returns>
        static string cubeToN (int n)
        {
            string result = "";
            
            for (int i = 0; i < n; i++)
            {
                result += (i*i*i).ToString() + ", ";
            }

            return result;
        }
    }
}