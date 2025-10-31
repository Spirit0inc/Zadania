using System.Windows;
using System.Windows.Controls;

namespace podstrelov_PR2
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnTask1_Click(object sender, RoutedEventArgs e)
        {
            NumberTaskWindow window = new NumberTaskWindow();
            window.ShowDialog();
        }

        private void BtnTask2_Click(object sender, RoutedEventArgs e)
        {
            StringTaskWindow window = new StringTaskWindow();
            window.ShowDialog();
        }

        private void BtnTask3_Click(object sender, RoutedEventArgs e)
        {
            ArraySearchWindow window = new ArraySearchWindow();
            window.ShowDialog();
        }

        private void BtnTask4_Click(object sender, RoutedEventArgs e)
        {
            ArrayReorderWindow window = new ArrayReorderWindow();
            window.ShowDialog();
        }

        private void BtnTask5_Click(object sender, RoutedEventArgs e)
        {
            MatrixSortWindow window = new MatrixSortWindow();
            window.ShowDialog();
        }
    }
}