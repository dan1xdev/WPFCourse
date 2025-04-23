using System.Windows;
using System.Windows.Controls;
using Laba9;

namespace MultiPageForm
{
    public partial class Page2 : Page
    {
        private readonly MainWindow _mainWindow;

        public Page2(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (!EmailTextBox.Text.Contains("@") || !EmailTextBox.Text.Contains("."))
            {
                MessageBox.Show("Введите корректный email");
                return;
            }

            if (string.IsNullOrWhiteSpace(PhoneTextBox.Text))
            {
                MessageBox.Show("Введите номер телефона");
                return;
            }

            _mainWindow.UserData.Email = EmailTextBox.Text;
            _mainWindow.UserData.Phone = PhoneTextBox.Text;

            NavigationService.Navigate(new Page3(_mainWindow));
        }
    }
}