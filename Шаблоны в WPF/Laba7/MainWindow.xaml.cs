using System.Windows;

namespace CustomButtonWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Кнопка работает корректно!", "Тест",
                          MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}