using System;
using System.Linq;
using System.Windows;
using System.Collections.Generic;

namespace podstrelov_PR2
{
    public partial class ArraySearchWindow : Window
    {
        public ArraySearchWindow()
        {
            InitializeComponent();
        }

        private void BtnFind_Click(object sender, RoutedEventArgs e)
        {
            string input = txtArray.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                txtResult.Text = "Введите массив чисел";
                return;
            }

            try
            {
                int[] numbers = input.Split(' ')
                                   .Where(s => !string.IsNullOrWhiteSpace(s))
                                   .Select(int.Parse)
                                   .ToArray();

                var result = FindNumbersWithSameDigits(numbers);

                if (result.Any())
                    txtResult.Text = $"Числа с одинаковыми цифрами: {string.Join(", ", result)}";
                else
                    txtResult.Text = "Чисел с одинаковыми цифрами не найдено";
            }
            catch (FormatException)
            {
                txtResult.Text = "Ошибка: введите целые числа через пробел";
            }
            catch (Exception ex)
            {
                txtResult.Text = $"Ошибка: {ex.Message}";
            }
        }

        private List<int> FindNumbersWithSameDigits(int[] numbers)
        {
            var result = new List<int>();

            foreach (int number in numbers)
            {
                string digits = Math.Abs(number).ToString();

                if (digits.Length > 1 && digits.All(c => c == digits[0]))
                {
                    result.Add(number);
                }
            }

            return result;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}