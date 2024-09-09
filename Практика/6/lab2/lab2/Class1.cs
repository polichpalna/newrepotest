using System;
namespace lab2
{
    public class IntArray
    {
        public int[,] array;
        /// <summary>
        /// Нахождение суммы нечестных чисел в стрке и определение максимальной
        /// </summary>
        /// <param name="maxOddSum">максимальная сумма</param>
        public int Find_Sum(out int maxOddSum)
        {
            int maxSumRow = 0;
            maxOddSum = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                int rowSum = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] % 2 != 0)
                    {
                        rowSum += array[i, j];
                    }
                }
                if (rowSum > maxOddSum)
                {
                    maxOddSum = rowSum;
                    maxSumRow = i;
                }
            }

            return maxSumRow;
        }
        /// <summary>
        /// Конструктор для создания экземпляра класса
        /// </summary>
        public IntArray()
        {

        }
        /// <summary>
        /// Конструктор для получения массива в класс
        /// </summary>
        /// <param name="arr">присвоение массива экземпляра классу</param>
        public IntArray(int[,] arr)
        {
            array = arr;
        }
        /// <summary>
        /// Метод для заполнения массива рандомными значения
        /// </summary>
        /// <param name="a">первое число диапазона для рандомных чисел</param>
        /// <param name="b">второе число диапазона для рандомных чисел</param>
        /// <param name="rows">количество строк массива</param>
        /// <param name="columns">количество столбцов массива</param>
        public void RandomIntArray(int a, int b, int rows, int columns)
        {
            array = new int[rows, columns];
            Random random = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array[i, j] = random.Next(a, b + 1); 
                }
            }
        }
    }
}
