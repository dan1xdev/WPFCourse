using System.Windows;
using System.Windows.Controls;

namespace MultiPageForm
{
    public partial class Page3 : Page
    {
        private readonly MainWindow _mainWindow;

        public Page3(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CityTextBox.Text) ||
                string.IsNullOrWhiteSpace(StreetTextBox.Text) ||
                string.IsNullOrWhiteSpace(HouseNumberTextBox.Text))
            {
                MessageBox.Show("Заполните обязательные поля");
                return;
            }

            _mainWindow.UserData.City = CityTextBox.Text;
            _mainWindow.UserData.Street = StreetTextBox.Text;
            _mainWindow.UserData.HouseNumber = HouseNumberTextBox.Text;
            _mainWindow.UserData.ApartmentNumber = ApartmentNumberTextBox.Text;

            string result = $"Данные:\n\n" +
                          $"Имя: {_mainWindow.UserData.FirstName}\n" +
                          $"Фамилия: {_mainWindow.UserData.LastName}\n" +
                          $"Дата рождения: {_mainWindow.UserData.BirthDate}\n" +
                          $"Email: {_mainWindow.UserData.Email}\n" +
                          $"Телефон: {_mainWindow.UserData.Phone}\n" +
                          $"Адрес: {_mainWindow.UserData.City}, {_mainWindow.UserData.Street}, " +
                          $"д. {_mainWindow.UserData.HouseNumber}";

            if (!string.IsNullOrWhiteSpace(_mainWindow.UserData.ApartmentNumber))
                result += $", кв. {_mainWindow.UserData.ApartmentNumber}";

            MessageBox.Show(result, "Результат");
        }
    }
}