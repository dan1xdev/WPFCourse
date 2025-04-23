using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HelloWorldWPF
{
    public partial class MainWindow : Window
    {
        private bool isOpened = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text + "1"; 
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text + "2";
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text + "3";
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text + "4";
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text + "5";
        }

        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text + "6";
        }

        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text + "7";
        }

        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text + "8";
        }

        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text + "9";
        }

        private void Btn0_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text + "0";
        }

        private void CBtn_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "";
            isOpened = false;
        }

        private void EqualBtn_Click(object sender, RoutedEventArgs e)
        {
            isOpened = false;
            try
            {
                var result = new DataTable().Compute(Display.Text, null);
                // Проверяем, является ли результат бесконечностью
                if (double.IsInfinity(Convert.ToDouble(result)))
                {
                    Display.Text = "Деление на ноль!";
                }
                else
                {
                    Display.Text = result.ToString();
                    Display.Text = Display.Text.Replace(",", ".");
                    HistoryText.Text = HistoryText.Text + " " + result.ToString();

                }
            }
            catch (Exception ex)
            {
                Display.Text = "Ошибка: " + ex.Message;
            }
        }

        private void MinusBtn_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text + "-";
        }

        private void MultyplyBtn_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text + "*";
        }

        private void PlusBtn_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text + "+";
        }

        private void DivBtn_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text + "/";
        }

        private void FloatBtn_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text + ".";
        }

        private void BracketBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isOpened)
            {
                Display.Text += ")";
                isOpened = false;
            }
            else
            {
                Display.Text += "(";
                isOpened = true;
            }
        }
    }
}