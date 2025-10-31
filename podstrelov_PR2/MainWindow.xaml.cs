using System.Windows;

namespace podstrelov_PR2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // При запуске показываем главную страницу с кнопками
            MainFrame.Navigate(new MainPage());
        }
    }
}