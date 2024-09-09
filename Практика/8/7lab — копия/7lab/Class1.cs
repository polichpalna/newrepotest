using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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

        public static List<Attestat> LoadFromFile1(string filename)
        {
            List<Attestat> attList = new List<Attestat>();
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    while (!reader.EndOfStream)
                    {
                        Attestat att = new Attestat();

                        att.group = reader.ReadLine();

                        att.obj = reader.ReadLine();

                        string[] grades = reader.ReadLine().Split(',');

                        att.five = int.Parse(grades[1]);
                        string[] grades1 = reader.ReadLine().Split(',');
                        att.four = int.Parse(grades1[1]);
                        string[] grades2 = reader.ReadLine().Split(',');
                        att.three = int.Parse(grades2[1]);
                        string[] grades3 = reader.ReadLine().Split(',');
                        att.two = int.Parse(grades[1]);
                        string[] grades4 = reader.ReadLine().Split(',');
                        att.not_att = int.Parse(grades4[1]);
                        double absalut = double.Parse(reader.ReadLine());

                        double quality = double.Parse(reader.ReadLine());
                        attList.Add(att);
                    }
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
