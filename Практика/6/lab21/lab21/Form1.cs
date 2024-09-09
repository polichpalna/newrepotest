using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using lab2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab21
{
    public partial class Form1 : Form
    {
        private IntArray arr1;
        int ot;
        int doc;
        int[,] arr;
        /// <summary>
        /// Конструктор формы
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            groupBox4.Visible = false;

        } 
        /// <summary>
        /// Преобразование в массив данных с datagridview создание экземпляров класса с методами
        /// </summary>
        private void ConvertToArray1()
        {
            int col = Convert.ToInt32(numericUpDown1.Value);
            int row = Convert.ToInt32(numericUpDown2.Value);
            arr = new int [row,col];
            for (int i = 0; i < row; i++)
            {
                // dataGridView1.Rows.Add();
                for (int j = 0; j < col; j++)
                {
                   arr[i,j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value );
                    if (arr[i, j] % 2 != 0)
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.LightSalmon;
                    }

                }
            }
            arr1 = new IntArray(arr);
        }

        /// <summary>
        /// Метод двойного нажатия на datagridview, который создает ячейки и столбцы, загружает данные и т.д., проверяет значения
        /// </summary>
        /// <param name="sender">указатель на button1</param>
        /// <param name="e">дополнительный аргумент</param>
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int col = Convert.ToInt32(numericUpDown1.Value);
            int row = Convert.ToInt32(numericUpDown2.Value);
            if (col == 0)
            {
                dataGridView1.ColumnCount = 0; ;
                dataGridView1.RowCount = 0;
                MessageBox.Show("Неверный формат данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            dataGridView1.ColumnCount = col;
            dataGridView1.RowCount = row;
           
            try
            {
                if (radioButton1.Checked)
                {
                    dataGridView1.RowCount = row;
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            dataGridView1.Rows[i].Cells[j].Value = 0;
                        }
                    }
                    dataGridView1.RowHeadersVisible = false;
                    dataGridView1.ReadOnly = false;
                }
                else if (radioButton2.Checked)
                {
                    ot = Convert.ToInt32(numericUpDown3.Value);
                    doc = Convert.ToInt32(numericUpDown4.Value);
                    dataGridView1.ReadOnly = true;
                    arr1 = new IntArray();
                    int[,] arr; 
                    arr1.RandomIntArray(ot, doc,row,col);
                    arr = arr1.array;

                    for (int i = 0; i < row; i++)
                    {
                        // dataGridView1.Rows.Add();
                        for (int j = 0; j < col; j++)
                        {
                            dataGridView1.Rows[i].Cells[j].Value = Convert.ToInt32(arr[i, j]);
                            // Окраска ячеек с нечетными числами
                            if (arr[i, j] % 2 != 0)
                            {
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.LightSalmon;
                            }
                        }
                    }
                    dataGridView1.RowHeadersVisible = false;
                }
                else
                {
                    dataGridView1.ReadOnly = true;
                }
            }
            catch (System.FormatException) 
            {
                MessageBox.Show("Неверный формат данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод выбора кнопки "Рандомное заполнение", очищает datagridview
        /// </summary>
        /// <param name="sender">указатель на radioButton2</param>
        /// <param name="e">дополнительный аргумент</param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
        }

        /// <summary>
        /// Метод выбора кнопки "Ручное заполнение", очищает datagridview
        /// </summary>
        /// <param name="sender">указатель на radioButton1</param>
        /// <param name="e">дополнительный аргумент</param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
        }

        /// <summary>
        /// Метод проверки в datagridview
        /// </summary>
        /// <param name="sender">указатель на dataGridView1</param>
        /// <param name="e">дополнительный аргумент</param>
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
        }

        /// <summary>
        /// Метод контроля нажатия клавиш в datagridview
        /// </summary>
        /// <param name="sender">указатель на dataGridView1</param>
        /// <param name="e">дополнительный аргумент</param>
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            bool hasMin = Text.Contains('-');

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&(e.KeyChar != '-' ))
            {
                e.Handled = true;
            }
            if ( (e.KeyChar == '-' && hasMin))
            {
                e.Handled = true;
            }

        }
        /// <summary>
        /// Метод нажатия на кнопку "Cумма нечетных по значениям элементов каждой строки массива"
        /// </summary>
        /// <param name="sender">указатель на button1</param>
        /// <param name="e">дополнительный аргумент</param>
        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            { 
                ConvertToArray1();
                int col = Convert.ToInt32(numericUpDown1.Value);
                int row = Convert.ToInt32(numericUpDown2.Value);
                int maxOddSum;
                int maxSumRow = arr1.Find_Sum(out maxOddSum);
                string result = "";
                for (int i = 0; i < row; i++)
                {
                    int oddSum = 0;
                    for (int j = 0; j < col; j++)
                    {
                        if (arr[i, j] % 2 != 0)
                        {
                            oddSum += arr[i, j];
                        }
                    }
                    result += $"{i + 1} строка - сумма нечетных элементов: {oddSum}\n";
                }
                MessageBox.Show(result);
                MessageBox.Show($"Номер строки с наибольшей суммой нечетных элементов: {maxSumRow + 1}\n" +
                                $"Сумма нечетных элементов этой строки: {maxOddSum}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}

