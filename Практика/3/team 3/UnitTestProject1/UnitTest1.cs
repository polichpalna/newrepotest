using Microsoft.VisualStudio.TestTools.UnitTesting;
using team_3;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
    
        public void TestMethod_nok()
        {
            // исходные данные для теста
            int first = 12;
            int second = 18;

            // ожидаемый результат
            int experted = 36;

            Class_nok nk = new Class_nok(first, second);
            //вызов тестируемой функции
            int actual = nk.calculate_nok();

            // сравнение результатов
            Assert.AreEqual(experted, actual, 0.0, "Ожидаемый результат не получен!");
        }

        [TestMethod]
        public void TestMethod_nod()
        {
            // исходные данные для теста
            int first = 12;
            int second = 18;

            // ожидаемый результат
            int experted = 6;

            Class_nod nd = new Class_nod(first, second);
            //вызов тестируемой функции
            int actual = nd.calculate_nod();
            // сравнение результатов
            Assert.AreEqual(experted, actual, 0.0, "Ожидаемый результат не получен!");
        }
        
    }
}
