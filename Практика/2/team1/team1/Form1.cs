using ClassLibrary1;
using System;
using System.Drawing;
using System.Linq;
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
        private void button1_Click(object sender, EventArgs e)
        {
            double z1;
            double z2;
            try
            {
                if (double.Parse(textBox1.Text) < 1&& double.Parse(textBox2.Text)>0 && double.Parse(textBox2.Text) < 1)
                {
                    double x = double.Parse(textBox1.Text);
                    double eps = double.Parse(textBox2.Text);

                    z1 = cl.calculate(x, eps);
                    z2 = cl.calculate_arcsin(x, eps);
                    label_res.Text = string.Format("Ответ:\r\n Сумма ряда = {0} \r\n arcsin(x)-x = {1}\r\n Количество членов ряда {2}", z1, z2, cl.n);
                }
                else
                { 
                    textBox1.Text = null;
                    textBox2.Text = null;
                    label_res.Text = "Выход за диапазон допустимых значений!";
                   
                    return;
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
                     
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
            if (textBox2.Text.Length > 0)
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
            if (textBox1.Text == "-")
            {
                button1.Enabled = false;
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool hasComm = (sender as TextBox).Text.Contains(',');
            bool hasMin = (sender as TextBox).Text.Contains('-');

            if ((e.KeyChar == ',' && hasComm) || (e.KeyChar == '-' && hasMin))
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',' && hasComm) || (e.KeyChar == '-' && hasMin))
            {
                e.Handled = true; 
            }

            if (e.KeyChar == '-' && hasComm)
            {
                e.Handled = true; 
            }
            if (e.KeyChar == ',' && hasMin&&textBox1.Text.Length>2)
            {
                e.Handled = true; 
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
            if (textBox1.Text.Length > 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
            if (textBox2.Text.StartsWith(","))
            {
                button1.Enabled = false;
            }
            if (textBox2.Text=="-")
            {
                button1.Enabled = false;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            bool hasComm = (sender as TextBox).Text.Contains(',');
            bool hasMin = (sender as TextBox).Text.Contains('-');

            if ((e.KeyChar == ',' && hasComm) || (e.KeyChar == '-' && hasMin))
            {
                e.Handled = true; 
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '-')
            {
                e.Handled = true; 
            }

        }

        private void label_res_MouseEnter(object sender, EventArgs e)
        {
            label_res.BackColor = Color.Aqua;
        }

        private void label_res_MouseLeave(object sender, EventArgs e)
        {
            label_res.BackColor = SystemColors.GradientInactiveCaption;
        }
    }
}
