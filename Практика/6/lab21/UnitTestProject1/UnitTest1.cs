using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using lab2;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FillArray_ValidInput_ArrayFilled()
        {
            // Arrange
            int rows = 3;
            int col = 4;
            IntArray arr1=new IntArray();
            // Act
            arr1.RandomIntArray(5, 10, rows, col);
           // arrayHelper.FillArray(rows, columns);

            // Assert
            Assert.IsNotNull(arr1.array, "Массив не пустой");
            Assert.AreEqual(rows, arr1.array.GetLength(0), "Неправильное количевто строк");
            Assert.AreEqual(col, arr1.array.GetLength(1), "Неправильное количевто столбцов");
        }

        [TestMethod]
        public void FindRowWithMaxOddSum_ValidInput_CorrectRowAndSum()
        {
          
            int[,] test = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };
            IntArray arr1 = new IntArray(test);
         
            int maxSumRow = arr1.Find_Sum(out int maxOddSum);

            // Assert
            Assert.AreEqual(2, maxSumRow, "Неправильная строка с максимальной суммой");
            Assert.AreEqual(16, maxOddSum, "Неправильная максимальная сумма");
        }
    }
}
