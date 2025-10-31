using System;
using System.Linq;
using System.Windows;

namespace podstrelov_PR2
{
    public partial class MatrixSortWindow : Window
    {
        private int[,] matrix;
        private int rows, cols;

        public MatrixSortWindow()
        {
            InitializeComponent();
        }

        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                rows = int.Parse(txtRows.Text);
                cols = int.Parse(txtCols.Text);

                if (rows <= 0 || cols <= 0)
                {
                    MessageBox.Show("Размеры матрицы должны быть положительными числами");
                    return;
                }

                matrix = new int[rows, cols];
                Random rnd = new Random();

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i, j] = rnd.Next(-10, 11);
                    }
                }

                DisplayMatrix(matrix, txtOriginal);
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные числа для размеров матрицы");
            }
        }

        private void BtnSort_Click(object sender, RoutedEventArgs e)
        {
            if (matrix == null)
            {
                MessageBox.Show("Сначала сгенерируйте матрицу");
                return;
            }

            try
            {
                int[] flatArray = new int[rows * cols];
                int index = 0;

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        flatArray[index++] = matrix[i, j];
                    }
                }

                // Сортировка по возрастанию
                var ascending = flatArray.OrderBy(x => x).ToArray();
                DisplayArrayAsMatrix(ascending, txtAscending, "По возрастанию:");

                // Сортировка по убыванию
                var descending = flatArray.OrderByDescending(x => x).ToArray();
                DisplayArrayAsMatrix(descending, txtDescending, "По убыванию:");

                // Находим минимальный и максимальный элементы
                int min = flatArray.Min();
                int max = flatArray.Max();
                txtMinMax.Text = $"Минимальный: {min}, Максимальный: {max}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void DisplayMatrix(int[,] matrix, System.Windows.Controls.TextBox textBox)
        {
            string result = "";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result += matrix[i, j].ToString().PadLeft(4);
                }
                result += Environment.NewLine;
            }
            textBox.Text = result;
        }

        private void DisplayArrayAsMatrix(int[] array, System.Windows.Controls.TextBox textBox, string title)
        {
            string result = title + Environment.NewLine;
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i].ToString().PadLeft(4);
                if ((i + 1) % cols == 0)
                    result += Environment.NewLine;
            }
            textBox.Text = result;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}