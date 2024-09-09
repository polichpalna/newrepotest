using System;
using System.Linq;
using System.Windows.Forms;
using lab2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab21
{
    public partial class Form1 : Form
    {
        private IntArray arr1;
        private IntArray arr2;
        private IntArray arr_res;
        Random r = new Random();
        int ot;
        int doc; 

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public Form1()
        {
            InitializeComponent();
           
        } 

        /// <summary>
        /// Преобразование в массив данных с datagridview создание экземпляров класса с методами
        /// </summary>
        private void ConvertToArray1()
        {
           

            int col = Convert.ToInt32(numericUpDown1.Value);

            int [] arr = new int [col];
            for (int i = 0; i < col; i++)
            {
                if (dataGridView1.Rows[0].Cells[i].Value != null)
                {
                    arr[i] = Convert.ToInt32(dataGridView1.Rows[0].Cells[i].Value);
                }
                else
                {
                    MessageBox.Show("Ошибка ввода данных в столбце" + i);
                    return;
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
            if (col == 0)
            {
                dataGridView1.ColumnCount = 0; ;
                dataGridView1.RowCount = 0;
                MessageBox.Show("Неверный формат данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            dataGridView1.ColumnCount = col;
            dataGridView1.RowCount = 1;
           
            try
            {
                if (radioButton1.Checked)
                {
              
                    dataGridView1.RowCount = 1;
                    for (int i = 0; i < col; i++)
                    {
                        dataGridView1.Columns[i].Name = (i + 1).ToString();
                        dataGridView1.Rows[0].Cells[i].Value = 0;
                    }
                    dataGridView1.ReadOnly = false;
                }
                else if (radioButton2.Checked)
                {
                    ot = Convert.ToInt32(numericUpDown3.Value);
                    doc = Convert.ToInt32(numericUpDown4.Value);
                    dataGridView1.ReadOnly = true;
                    arr1 = new IntArray(col);
                    int[] arr; 
                    arr1.RandomIntArray(ot, doc); 
                    arr= arr1.array;
                    for (int i = 0; i < col; i++)
                    {
                        dataGridView1.Columns[i].Name = (i).ToString(); 
                        dataGridView1.Rows[0].Cells[i].Value = Convert.ToInt32(arr[i]);
                    }
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
           
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
        }

        /// <summary>
        /// Метод проверки в datagridview
        /// </summary>
        /// <param name="sender">указатель на dataGridView1</param>
        /// <param name="e">дополнительный аргумент</param>
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
           

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int value;
                if (!int.TryParse(e.FormattedValue.ToString(), out value))
                {
                    MessageBox.Show("Введите корректное числовое значение.", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }

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
        /// Метод нажатия на кнопку "Найти индексы и поменять местами элементы кратные трем"
        /// </summary>
        /// <param name="sender">указатель на button1</param>
        /// <param name="e">дополнительный аргумент</param>
        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            { 
                ConvertToArray1();
                arr1.first_last_ind();
                int g =arr1.firstIndex;
                int gs = arr1.lastIndex;
           
                for (int i = 0; i < arr1.Length; i++)
                {
                    dataGridView1.Columns[i].Name = (i + 1).ToString();
                    dataGridView1.Rows[0].Cells[i].Value = Convert.ToInt32(arr1.array[i]);
                }
                label1.Text = string.Format("Первый индекс элемента кратного трём {0} \r\nПоследний индекс элемента кратного трём {1}", arr1.firstIndex, arr1.lastIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Метод нажатия на кнопку "Суммма элементов между первым и последним элементом кратным трем"
        /// </summary>
        /// <param name="sender">указатель на button2</param>
        /// <param name="e">дополнительный аргумент</param>
        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                ConvertToArray1();
                arr1.first_last_ind();
                int a = arr1.SumArray();
                label1.Text = string.Format("Первый индекс элемента кратного трём {0} \r\nПоследний индекс элемента кратного трём {1}\r\nСумма элементов стоящих между ними {2}", arr1.firstIndex, arr1.lastIndex, a);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}

