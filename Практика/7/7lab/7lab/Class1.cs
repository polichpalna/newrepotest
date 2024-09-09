using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace _7lab
{
    public class Attestat
    {
        public string group { get; set; }
        public string obj { get; set; }

        public int five { get; set; }
        public int four { get; set; }
        public int three { get; set; }
        public int two { get; set; }
        public int not_att { get; set; }

        public double abs
        {
            get
            {
                int totalGrades = five + four + three + two + not_att; // Общее количество оценок
                int sumWithoutTwos = five + four + three; // Сумма оценок без двоек
                return (double)sumWithoutTwos / totalGrades * 100;
            }
        }

        public double qual
        {
            get
            {
                int totalGrades = five + four + three + two + not_att; // Общее количество оценок
                int sumFoursAndFives = five + four; // Сумма четвёрок и пятёрок
                return (double)sumFoursAndFives / totalGrades * 100;
            }
        }

        public Attestat()
        {
           
        }

        // Метод для записи данных в файл 
        public void SaveToFile(string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename, true))
                {
                    writer.WriteLine(group);
                    writer.WriteLine(obj);
                    writer.WriteLine($"5,{five}");
                    writer.WriteLine($"4,{four}");
                    writer.WriteLine($"3,{three}");
                    writer.WriteLine($"2,{two}");
                    writer.WriteLine($"н/а,{not_att}");

                    // Добавляем запись абсолютной и качественной успеваемости
                    writer.WriteLine(abs);
                    writer.WriteLine(qual);
                }
            }
            catch
            {
                throw new Exception("Ошибка при сохранении данных: ");
            }
        }
        public Attestat(string group, string obj, int five, int four, int three, int two, int not_att, double absalut, double quality)
        {
            this.group = group;
            this.obj = obj;
            this.five = five;
            this.four = four;
            this.three = three;
            this.two = two;
            this.not_att = not_att;

        }

        public static List<Attestat> LoadFromFile1(string filename)
        {
            List<Attestat> attList = new List<Attestat>();
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {

                    // проверяем, что файл не пустой
                    if (reader.EndOfStream)
                    {
                        throw new Exception("Файл пуст");
                    }

                    // проверяем, что первая строка содержит имя группы
                    string group = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(group))
                    {
                        MessageBox.Show("Неверный формат файла: отсутствует имя группы");
                    }

                    // проверяем, что вторая строка содержит имя предмета
                    string obj = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(obj))
                    {
                        MessageBox.Show("Неверный формат файла: отсутствует имя предмета");
                    }

                    // читаем оценки и проверяем, что они соответствуют формату "оценка,количество"
                    string[] grades = reader.ReadLine().Split(',');
                    if (grades.Length != 2)
                    {
                        MessageBox.Show("Неверный формат файла: неверный формат оценок");
                    }
                    int five = int.Parse(grades[1]);

                    string[] grades1 = reader.ReadLine().Split(',');
                    if (grades1.Length != 2)
                    {
                        MessageBox.Show("Неверный формат файла: неверный формат оценок");
                    }
                    int four = int.Parse(grades1[1]);

                    string[] grades2 = reader.ReadLine().Split(',');
                    if (grades2.Length != 2)
                    {
                        MessageBox.Show("Неверный формат файла: неверный формат оценок");
                    }
                    int three = int.Parse(grades2[1]);

                    string[] grades3 = reader.ReadLine().Split(',');
                    if (grades3.Length != 2)
                    {   
                        MessageBox.Show("Неверный формат файла: неверный формат оценок");
                    }
                    int two = int.Parse(grades3[1]);

                    string[] grades4 = reader.ReadLine().Split(',');
                    if (grades4.Length != 2)
                    {
                        MessageBox.Show("Неверный формат файла: неверный формат оценок");
                    }
                    int not_att = int.Parse(grades4[1]);

                    // проверяем, что файл содержит две строки с абсолютной и качественной успеваемостью
                    double absalut = double.Parse(reader.ReadLine());
                    double quality = double.Parse(reader.ReadLine());

                    // создаем экземпляр класса Attestat и добавляем его в список
                    Attestat att = new Attestat(group, obj, five, four, three, two, not_att, absalut, quality);
                    attList.Add(att);

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при загрузке данных: " + ex.Message);
            }
            return attList;
        }
    }
}
