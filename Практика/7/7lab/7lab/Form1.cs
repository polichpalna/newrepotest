using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.IO;


namespace _7lab
{
    public partial class Form1 : Form
    {
        SaveFileDialog saveFileDialog;
        string name ="";
        int ck = 0;
        public Form1()
        {
            InitializeComponent();
        
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            if (name!="")
            {
                Attestat at = new Attestat();
                at.group = comboBox1.Text;
                at.obj = comboBox2.Text;
                at.five = (int)numericUpDown1.Value;
                at.four = (int)numericUpDown2.Value;
                at.three = (int)numericUpDown3.Value;
                at.two = (int)numericUpDown4.Value;
                at.not_att = (int)numericUpDown5.Value;

                at.SaveToFile(name);
            }
            else
            { ck++;
                saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "TXT files (*.txt)|*.txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Attestat at = new Attestat();
                    at.group = comboBox1.Text;
                    at.obj = comboBox2.Text;
                    at.five = (int)numericUpDown1.Value;
                    at.four = (int)numericUpDown2.Value;
                    at.three = (int)numericUpDown3.Value;
                    at.two = (int)numericUpDown4.Value;
                    at.not_att = (int)numericUpDown5.Value;
                    name = saveFileDialog.FileName;
                    at.SaveToFile(saveFileDialog.FileName);
                    
                }
            }    
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.ChartAreas[0].BackColor = Color.White;
     
            chart1.Series.Add(new Series() { ChartType = SeriesChartType.Bar });

            List<string> list = new List<string>();
            List<double> listy = new List<double>();

            List<Attestat> attList = Attestat.LoadFromFile1(name);
            foreach (Attestat pr in attList)
            {
                if (pr.group == comboBox3.Text)
                {
                    list.Add(pr.obj.ToString());
                    listy.Add(pr.abs);
                }
            }

            string[] xValues =list.ToArray();
            double[] yValues = listy.ToArray() ;

            chart1.ChartAreas[0].AxisY.Title = "Успеваемость";
           
            chart1.ChartAreas[0].AxisX.IsReversed = true;
            chart1.Series[0].Points.DataBindXY(xValues, yValues);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "TXT files (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Записываем данные в файл
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                   
                    // Записываем данные из таблицы данных в файл
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        writer.WriteLine(row.Cells["Номер группы"].Value);
                        writer.WriteLine(row.Cells["Предмет"].Value);
                        writer.WriteLine($"5,{row.Cells["5 (отл)"].Value}");
                        writer.WriteLine($"4,{row.Cells["4 (хор)"].Value}");
                        writer.WriteLine($"3,{row.Cells["3 (удв)"].Value}");
                        writer.WriteLine($"2,{row.Cells["2 (неудв)"].Value}");
                        writer.WriteLine($"н/а,{row.Cells["не аттестованно"].Value}");
                        writer.WriteLine(row.Cells["Абсолютная успеваемость"].Value);
                        writer.WriteLine(row.Cells["Качественная успеваемость"].Value);
                        
                    }
                    name = saveFileDialog.FileName;
                }

                MessageBox.Show("Данные успешно экспортированы!");
            }
        
          
         }

        private void button2_Click(object sender, EventArgs e)
        {
            // Выбираем файл с данными
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TXT files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Номер группы", typeof(string));
                dataTable.Columns.Add("Предмет", typeof(string));
                dataTable.Columns.Add("5 (отл)", typeof(int));
                dataTable.Columns.Add("4 (хор)", typeof(int));
                dataTable.Columns.Add("3 (удв)", typeof(int));
                dataTable.Columns.Add("2 (неудв)", typeof(int));
                dataTable.Columns.Add("не аттестованно", typeof(int));
                dataTable.Columns.Add("Абсолютная успеваемость", typeof(int));
                dataTable.Columns.Add("Качественная успеваемость", typeof(int));

                foreach (var val in Attestat.LoadFromFile1(openFileDialog.FileName))
                {
                    dataTable.Rows.Add(val.group, val.obj, val.five, val.four, val.three, val.two, val.not_att, val.abs, val.qual);
                }

                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                name = openFileDialog.FileName;

                dataGridView1.DataSource = dataTable;

                dataGridView1.RowHeadersVisible = false;
            }
        }

        private void dataGridView1_MouseEnter(object sender, EventArgs e)
        {
            if (name != "")
            {

                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Номер группы", typeof(string));
                dataTable.Columns.Add("Предмет", typeof(string));
                dataTable.Columns.Add("5 (отл)", typeof(int));
                dataTable.Columns.Add("4 (хор)", typeof(int));
                dataTable.Columns.Add("3 (удв)", typeof(int));
                dataTable.Columns.Add("2 (неудв)", typeof(int));
                dataTable.Columns.Add("не аттестованно", typeof(int));
                dataTable.Columns.Add("Абсолютная успеваемость", typeof(int));
                dataTable.Columns.Add("Качественная успеваемость", typeof(int));

                foreach (var val in Attestat.LoadFromFile1(name))
                {
                    dataTable.Rows.Add(val.group, val.obj, val.five, val.four, val.three, val.two, val.not_att, val.abs, val.qual);
                }

                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }              

                dataGridView1.DataSource = dataTable;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
