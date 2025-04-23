using System.Windows;
using System.Windows.Controls;
using Laba9;

namespace MultiPageForm
{
    public partial class Page1 : Page
    {
        private readonly MainWindow _mainWindow;

        public Page1(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(LastNameTextBox.Text) ||
                BirthDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            _mainWindow.UserData.FirstName = FirstNameTextBox.Text;
            _mainWindow.UserData.LastName = LastNameTextBox.Text;
            _mainWindow.UserData.BirthDate = BirthDatePicker.SelectedDate.Value.ToShortDateString();

            NavigationService.Navigate(new Page2(_mainWindow));
        }
    }
}