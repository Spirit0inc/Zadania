using System;
using System.Windows;

namespace podstrelov_PR2
{
    public partial class NumberTaskWindow : Window
    {
        public NumberTaskWindow()
        {
            InitializeComponent();
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            string binaryString = txtBinary.Text.Trim();

            if (string.IsNullOrEmpty(binaryString))
            {
                txtResult.Text = "Введите двоичное число";
                return;
            }

            foreach (char c in binaryString)
            {
                if (c != '0' && c != '1')
                {
                    txtResult.Text = "Ошибка: введите только 0 и 1";
                    return;
                }
            }

            if (binaryString.Length > 10000)
            {
                txtResult.Text = "Ошибка: число слишком длинное";
                return;
            }

            try
            {
                bool isDivisibleBy15 = CheckDivisibilityBy15(binaryString);
                txtResult.Text = isDivisibleBy15 ? "Делится на 15" : "Не делится на 15";
            }
            catch (Exception ex)
            {
                txtResult.Text = $"Ошибка: {ex.Message}";
            }
        }

        private bool CheckDivisibilityBy15(string binary)
        {
            int remainder = 0;
            foreach (char bit in binary)
            {
                remainder = (remainder * 2 + (bit - '0')) % 15;
            }
            return remainder == 0;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}