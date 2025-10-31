using System;
using System.Linq;
using System.Windows;

namespace podstrelov_PR2
{
    public partial class ArrayReorderWindow : Window
    {
        public ArrayReorderWindow()
        {
            InitializeComponent();
        }

        private void BtnReorder_Click(object sender, RoutedEventArgs e)
        {
            string arrayInput = txtArray.Text.Trim();
            string mInput = txtM.Text.Trim();

            if (string.IsNullOrEmpty(arrayInput) || string.IsNullOrEmpty(mInput))
            {
                txtResult.Text = "Введите массив и длину m";
                return;
            }

            try
            {
                int[] numbers = arrayInput.Split(' ')
                                        .Where(s => !string.IsNullOrWhiteSpace(s))
                                        .Select(int.Parse)
                                        .ToArray();

                int m = int.Parse(mInput);
                int n = numbers.Length - m;

                if (m <= 0 || m >= numbers.Length)
                {
                    txtResult.Text = "Ошибка: m должно быть между 1 и длиной массива-1";
                    return;
                }

                txtOriginal.Text = string.Join(" ", numbers);

                // Алгоритм перестановки отрезков
                ReverseArray(numbers, 0, m - 1);
                ReverseArray(numbers, m, numbers.Length - 1);
                ReverseArray(numbers, 0, numbers.Length - 1);

                txtResult.Text = string.Join(" ", numbers);
            }
            catch (FormatException)
            {
                txtResult.Text = "Ошибка: введите корректные числа";
            }
            catch (Exception ex)
            {
                txtResult.Text = $"Ошибка: {ex.Message}";
            }
        }

        private void ReverseArray(int[] array, int start, int end)
        {
            while (start < end)
            {
                int temp = array[start];
                array[start] = array[end];
                array[end] = temp;
                start++;
                end--;
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}