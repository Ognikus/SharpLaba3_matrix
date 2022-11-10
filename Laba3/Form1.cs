using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba3
{
    public partial class Form1 : Form
    {
        int m, n; //размеры матрицы
        double[,] A; //сама матрица
        double[,] S; //Изменённая матрица
        public Form1()
        {
            InitializeComponent();
        }
        // Кнопка переноса данных и DataGredViev в массив
        private void button2_Click(object sender, EventArgs e)
        {
            string elem = "";
            bool correct = true;
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    try
                    {
                        elem = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        A[i, j] = Convert.ToDouble(elem);
                        label5.Text = "";
                    }
                    catch (Exception any)
                    {
                        label5.Text = "Значение элемента" +
                        "A[" + i.ToString() + ", " + j.ToString() + " ]"
                        + " не корректно. Повторите ввод!";
                        dataGridView1.Rows[i].Cells[j].Selected = true;
                        return;
                    }
                }

        }
        // Кнопка нахождения суммы строк матрицы
        private void button3_Click(object sender, EventArgs e)
        {
            {
                MultMatr(A);
            }
            void MultMatr(double[,] A)
            {
                int rows = A.GetUpperBound(0) + 1;    // количество строк
                int columns = A.GetUpperBound(1) + 1;        // количество столбцов
                for (int i = 0; i < rows; i++)
                {
                    double accumulator = 0;
                    for (int j = 0; j < columns; j++)
                    {
                        accumulator += A[i, j];
                    }
                    int b = 1 + i;
                    label4.Text += ("\nСума в строке " + b + " = " + accumulator + ' ');
                }
            }
        }
        // Получение строк и столбцов для создания колонок в DataGreedViev
        private void AddColumns(int n, DataGridView dgw)
        {
            //добавляет n столбцов в элемент управления dgw
            //Заполнение DGView столбцами
            DataGridViewColumn column;
            for (int i = 0; i < n; i++)
            {
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "Column" + i.ToString();
                column.Name = "Column" + i.ToString();
                dgw.Columns.Add(column);
            }
        }
        private void AddRows(int m, DataGridView dgw)
        {
            //добавляет m строк в элемент управления dgw 
            //Заполнение DGView строками
            for (int i = 0; i < m; i++)
            {
                dgw.Rows.Add();
                dgw.Rows[i].HeaderCell.Value
                = "row" + i.ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //создание матрицы
            m = Convert.ToInt32(textBox1.Text);
            n = Convert.ToInt32(textBox2.Text);
            A = new double[m, n];
            //Чистка DGView, если они не пусты
            int k = 0;
            k = dataGridView1.ColumnCount;
            if (k != 0)
                for (int i = 0; i < k; i++)
                    dataGridView1.Columns.RemoveAt(0);
            //Заполнение DGView столбцами
            AddColumns(m, dataGridView1);
            //Заполнение DGView строками
            AddRows(n, dataGridView1);
        }
    }
}
