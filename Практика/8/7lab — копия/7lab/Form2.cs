using System;
using System.Drawing;
using System.Windows.Forms;

namespace _7lab
{
    public partial class Form2 : Form
    {
        public int QuizTime { get; private set; }
        public Color FormColor { get; private set; }
        public Form2(int quizTime, Color formColor)
        {
            InitializeComponent();
            numericUpDown1.Value = quizTime;
            colorDialog1.Color = formColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuizTime = (int)numericUpDown1.Value;
            FormColor = colorDialog1.Color;
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                panel1.BackColor = colorDialog1.Color;
            }
        }
    }
}
