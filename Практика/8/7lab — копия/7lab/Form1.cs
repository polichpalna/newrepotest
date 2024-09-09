using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace _7lab
{
    public partial class Form1 : Form
    {
        private List<string> img;
        private int ind = 0;
        private Timer tim;
        private Timer quizTimer;
        private Random random = new Random();
        private int correctAnswers = 0;
        private int totalQuestions = 0;
        private DateTime quizStartTime;
        private int score = 0;
        private int timeLeft = 60; // in seconds
        private List<Mushroom> mushrooms = new List<Mushroom>();
        private Mushroom currentMushroom;
        int quizDuration = 60;
        int bestScore = 0;
        public Form1()
        {
            InitializeComponent();
            LoadImageFiles();
            init_timer();
            InitializeQuizTimer();
            button3.Visible = false;
            label3.Visible = false;
          
            LoadSettings();

        }
        private void LoadImageFiles()
        {
            string imagesPath = Path.Combine(Application.StartupPath, "images");
            img = Directory.GetFiles(imagesPath, "*.jpeg").Concat(Directory.GetFiles(imagesPath, "*.jpg")).ToList();
            if (img.Any())
            {
                DisplayImage(0);
            }
            else
            {
                MessageBox.Show("Изображение не найдено");
            }
        }

        private void DisplayImage(int index)
        {
            if (img.Any())
            {
                pictureBox1.Image = Image.FromFile(img[index]);
            }
        }

        private void init_timer()
        {
            tim = new Timer();
            tim.Interval = 2000; 
            tim.Tick += tim_tick;
        }
        private void tim_tick(object sender, EventArgs e)
        {
            ind = (ind + 1) % img.Count;
            DisplayImage(ind);
        }
     

        private void button_prev_Click(object sender, EventArgs e)
        {
            ind = (ind - 1 + img.Count) % img.Count;
            DisplayImage(ind);
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            ind = (ind + 1) % img.Count;
            DisplayImage(ind);
        }

        private void button_strslsh_Click(object sender, EventArgs e)
        {
            tim.Start();
        }
        private void QuizTimer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            label3.Text = $"Осталось времени: {timeLeft} сек";
            if (timeLeft <= 0)
            {
                EndQuiz();
            }
        }
        private void EndQuiz()
        {
            quizTimer.Stop();
            int result = (score * 100) / 10;
            if (score > bestScore)
            {
                bestScore = score;
                SaveSettings();
            }
            MessageBox.Show($"Ваша оценка: {result} \nЛучший результат: {bestScore *10}");

            groupBox1.Visible = false;
            button_next.Visible = true;
            button_prev.Visible = true;
            button_strslsh.Visible = true;
            button1.Visible = true;
            button4.Visible = true;
            button2.Visible = true;
            label3 .Visible = false;
            button3.Visible = false;
            button5.Visible = true;
        }
        private void InitializeQuizTimer()
        {
            quizTimer = new Timer();
            quizTimer.Interval = 1000; // 1 second
            quizTimer.Tick += QuizTimer_Tick;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Path.Combine(Application.StartupPath, "images");
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg)|*.jpg; *.jpeg";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }
        private void NextQuestion()
        {
            if (totalQuestions == 0)
            {
                EndQuiz();
                return;
            }

            totalQuestions--;

            int index = random.Next(mushrooms.Count);
            currentMushroom = mushrooms[index];
            pictureBox1.Image = Image.FromFile(currentMushroom.ImagePath);

            var answers = mushrooms.Select(m => m.Name).OrderBy(x => random.Next()).Take(4).ToList();
            if (!answers.Contains(currentMushroom.Name))
            {
                answers[random.Next(4)] = currentMushroom.Name;
            }

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(answers.ToArray());
            comboBox1.SelectedIndex = 0;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            button_next.Visible = false;
            button_prev.Visible = false;
            button_strslsh.Visible = false;
            button1.Visible = false;
            button3.Visible = true;
            button4.Visible = false;
            button5.Visible = false;
            label3.Visible = true;

            LoadMushrooms();
            totalQuestions = 10; 
            score = 0;
            timeLeft = quizDuration;
            quizTimer.Start();
            NextQuestion();
            tim.Stop();
            button2.Visible= false;
        }
        private void LoadMushrooms()
        {
            mushrooms.Add(new Mushroom { Name = "Белый гриб", IsEdible = true, ImagePath = "images/1.jpg" });
            mushrooms.Add(new Mushroom { Name = "Шампиньон", IsEdible = true, ImagePath = "images/2.jpeg" });
            mushrooms.Add(new Mushroom { Name = "Лисичка", IsEdible = true, ImagePath = "images/3.jpg" });
            mushrooms.Add(new Mushroom { Name = "Сатанинский гриб", IsEdible = false, ImagePath = "images/10.jpeg" });
            mushrooms.Add(new Mushroom { Name = "Подберезовик", IsEdible = true, ImagePath = "images/9.jpeg" });
            mushrooms.Add(new Mushroom { Name = "Ложные опята", IsEdible = false, ImagePath = "images/8.jpeg" });
            mushrooms.Add(new Mushroom { Name = "Мухомор", IsEdible = false, ImagePath = "images/7.jpg" });
            mushrooms.Add(new Mushroom { Name = "Бледная поганка", IsEdible = false, ImagePath = "images/6.jpeg" });
            mushrooms.Add(new Mushroom { Name = "Рыжик", IsEdible = true, ImagePath = "images/5.jpg" });
            mushrooms.Add(new Mushroom { Name = "Ленин", IsEdible = false, ImagePath = "images/4.jpg" });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool isCorrect = (comboBox1.SelectedItem.ToString() == currentMushroom.Name) && ((radioButton1.Checked && currentMushroom.IsEdible) ||  (radioButton2.Checked && !currentMushroom.IsEdible));

            if (isCorrect)
            {
                score++;
            }
            NextQuestion();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tim.Stop();
        }
      
        private void LoadSettings()
        {
            quizDuration = Properties.Settings.Default.QuizTime;
            this.BackColor = Properties.Settings.Default.FormColor;
            bestScore = Properties.Settings.Default.BestScore;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.QuizTime = quizDuration;
            Properties.Settings.Default.FormColor = this.BackColor;
            Properties.Settings.Default.BestScore = bestScore;
            Properties.Settings.Default.Save();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (var settingsForm = new Form2(quizDuration, this.BackColor))
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    quizDuration = settingsForm.QuizTime;
                    this.BackColor = settingsForm.FormColor;
                    SaveSettings();
                }
            }
        }
    }
    public class Mushroom
    {
        public string Name { get; set; }
        public bool IsEdible { get; set; }
        public string ImagePath { get; set; }
    }
}
