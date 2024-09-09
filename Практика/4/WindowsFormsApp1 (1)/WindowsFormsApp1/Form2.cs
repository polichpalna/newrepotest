using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class  Form2 : Form
    {
        Form1 frm;
        public Form2(Form1 f)
        {
            InitializeComponent();
            frm = f;
            Text = "Настройки";
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            frm.timer.Interval = (int)numericUpDown1.Value;
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
           
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1 = new ColorDialog();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                frm.setcolor(colorDialog1.Color);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1 = new ColorDialog();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                frm.setcolor_for(colorDialog1.Color);
            }
        }
    }
}
