using System;
using System.Windows;

namespace podstrelov_PR2
{
    public partial class StringTaskWindow : Window
    {
        public StringTaskWindow()
        {
            InitializeComponent();
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            string input = txtInput.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                txtResult.Text = "Введите строку";
                return;
            }

            if (int.TryParse(input, out _))
            {
                txtResult.Text = "1 (целое число)";
                return;
            }

            if (double.TryParse(input, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out _))
            {
                txtResult.Text = "2 (вещественное число)";
                return;
            }

            txtResult.Text = "0 (не число)";
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}