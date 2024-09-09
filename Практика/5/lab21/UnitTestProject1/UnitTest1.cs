using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using lab2;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethoProisved()
        {
            int[] A = {-9, 5, 0, 3, -4, 8, 2};
            IntArray arr = new IntArray(A);
            double expected = 0; 
            arr.first_last_ind();
            int pr = arr.SumArray();
            Assert.AreEqual(expected,pr,"Ожидаемое значение не получено.");
        }

        [TestMethod]
        public void TestMethodPerestan()
        {
            try
            {
                int[] A = { 1, 5, 4, 1, -4, 8, 2 };
                int[] expected = { 3, 5, 4,-9, -4, 8, 2 };
                IntArray arr = new IntArray(A);
                arr.first_last_ind();
                int[] B = arr.array;
                // Assert.AreEqual(expected, B, "Ожидаемое значение не получено.");
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Кратные трём элементы отсутствуют.");
                return;
            }
            Assert.Fail("Ожидаемое исключение не получено.");
        }
        [TestMethod]
        public void TestMethodfirstindex()
        {
            int[] A = { 1, 5, 3, 1, -4, 6, 2 };
            IntArray arr = new IntArray(A);
            int expected =2;
                
            arr.first_last_ind();
            int B = arr.firstIndex;
            Assert.AreEqual(expected, B, "Ожидаемое значение не получено.");
        }
    }
}
