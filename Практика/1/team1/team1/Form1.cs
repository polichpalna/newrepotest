using ClassLibrary1;
using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace team1
{
    public partial class Form1 : Form
    {
        Class1 cl;
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            cl = new Class1();  

        }

        private void label_z1_MouseEnter(object sender, EventArgs e)
        {
            label_z1.BackColor = Color.Aqua;
        }

        private void label_z1_MouseLeave(object sender, EventArgs e)
        {
            label_z1.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double val = double.Parse(textBox1.Text);

            double z1 = cl.res_z1(val);
            double z2 = cl.res_z2(val);

            label_z1.Text="Ответ:  z1 = "+z1+ "    z2 = " + z2;          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (textBox1.Text.Length > 0) 
            {
                button1.Enabled = true; 
            }
            else
            { 
                button1.Enabled = false;
            }
            if (textBox1.Text.StartsWith(","))  
            {
                button1.Enabled = false;
            }
         
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cl.grade = true;
            cl.rade = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //// Проверяем, есть ли уже запятая или минус в тексте
            bool hasComm = (sender as TextBox).Text.Contains(',');
            bool hasMin = (sender as TextBox).Text.Contains('-');

            // Если введенная клавиша - запятая и уже есть запятая или минус, или если введенный минус и уже есть минус
            if ((e.KeyChar == ',' && hasComm) || (e.KeyChar == '-' && hasMin))
            {
                e.Handled = true; // Отклоняем ввод
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
          
            if ((e.KeyChar == ',' && hasComm) || (e.KeyChar == '-' && hasMin))
            {
                e.Handled = true; // Отклоняем ввод
            }


            if (e.KeyChar == '-' && hasComm)
            {
                e.Handled = true; 
            }

            if (e.KeyChar == ',' && hasMin && textBox1.Text.Length > 2)
            {
                e.Handled = true; 
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cl.grade =false;
            cl.rade = true;
        }

    }
}
