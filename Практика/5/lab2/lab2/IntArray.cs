using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class IntArray
    {
        public int[] array;
        private int length;
        public int firstIndex = -1;
        public int lastIndex = -1;
        int pr = 0;
        /// <summary>
        /// Конструктор для создания экземпляра пустого массива
        /// </summary>
        /// <param name="length">присвоение длины массива экземпляра классу</param>
        public IntArray(int length)
        {
            
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "Указано неверное значение длины массива.");
            }
            this.length = length;
            array = new int[length];
        }
        /// <summary>
        /// Конструктор для получения массива в класс
        /// </summary>
        /// <param name="arr">присвоение массива экземпляра классу</param>
        public IntArray(params int[] arr)
        {       
            length = arr.Length;
            array = arr;
        }
        /// <summary>
        /// Кнопка "Вычислить"- запускает метод вычисления среднего значения положительных элементов.
        /// </summary
        public int Length
        {
            get
            { 
                return length;
            }
        }
        /// <summary>
        /// Метод для заполнения массива рандомными значения
        /// </summary>
        /// <param name="a">первое число диапазона для рандомных чисел</param>
        /// <param name="b">второе число диапазона для рандомных чисел</param>
        public void RandomIntArray( int a, int b) 
        {
            
            Random rand = new Random();

            for (int i = 0; i < length; i++)
            {
                array[i] = rand.Next(a, b + 1);
            }
        }
        /// <summary>
        /// Вычисление номера первого кратного 3 и последнего кратного 3 элемента массива и изменение их в массиве местами
        /// </summary>
        public void first_last_ind()
        {
           
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 3 == 0)
                {
                    if (firstIndex == -1)
                    {
                        firstIndex = i;
                    }
                    lastIndex = i;
                }
            }
            if (firstIndex == -1 || lastIndex == -1)
            {
                throw new Exception("Кратные трём элементы отсутствуют.");
               
            }
            int temp = array[firstIndex];
            array[firstIndex] = array[lastIndex];
            array[lastIndex] = temp;
        } 
        /// <summary>
        /// Вычисление произведения элементов, стоящих между первым кратным 3 и последнего кратным 3 элементами массива. 
        /// </summary>
        public int SumArray()
        {
            
            for (int i = firstIndex + 1; i < lastIndex; i++)
            {
                pr += array[i];
            }
            return pr;
        }

    }
}
