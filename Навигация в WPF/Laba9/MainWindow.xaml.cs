using System.Windows;
using Laba9;

namespace MultiPageForm
{
    public partial class MainWindow : Window
    {
        public UserData UserData { get; set; } = new UserData();

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Page1(this));
        }
    }

    public class UserData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
    }
}