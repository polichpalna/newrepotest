using System;
using System.Windows.Forms;

namespace team_3
{
    public partial class Form1 : Form
    {
        int res;
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = false; 
            radioButton2.Checked = false;
            label1.Text = null;
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Class_nod nod = new Class_nod(((int)numericUpDown1.Value), ((int)numericUpDown2.Value));
            res = nod.calculate_nod();
            label1.Text = res.ToString();
            label1.Text = string.Format("НОД:{0}", res);

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Class_nok nok = new Class_nok(((int)numericUpDown1.Value), ((int)numericUpDown2.Value));
            res = nok.calculate_nok();
            label1.Text = res.ToString();
            label1.Text = string.Format("НОК:{0}", res);
     
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Class_nod nod = new Class_nod(((int)numericUpDown1.Value), ((int)numericUpDown2.Value));
                res = nod.calculate_nod();
                label1.Text = res.ToString();
                label1.Text = string.Format("НОД:{0}", res);

            }
            else if (radioButton2.Checked) {
                Class_nok nok = new Class_nok(((int)numericUpDown1.Value), ((int)numericUpDown2.Value));
                res = nok.calculate_nok();
                label1.Text = res.ToString();
                label1.Text = string.Format("НОК:{0}", res);
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Class_nod nod = new Class_nod(((int)numericUpDown1.Value), ((int)numericUpDown2.Value));
                res = nod.calculate_nod();
                label1.Text = res.ToString();
                label1.Text = string.Format("НОД:{0}", res);

            }
            else if (radioButton2.Checked)
            {
                Class_nok nok = new Class_nok(((int)numericUpDown1.Value), ((int)numericUpDown2.Value));
                res = nok.calculate_nok();
                label1.Text = res.ToString();
                label1.Text = string.Format("НОК:{0}", res);
            }
        }

    }
}
