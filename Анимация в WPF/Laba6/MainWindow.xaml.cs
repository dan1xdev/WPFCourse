using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AnimatedCalculator
{
    public partial class MainWindow : Window
    {
        private string currentNumber = "";
        private string storedNumber = "";
        private string operation = "";
        private bool newInput = true;

        public MainWindow()
        {
            InitializeComponent();
            Display.Text = "0";
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            if (newInput)
            {
                currentNumber = "";
                newInput = false;
            }

            var button = (Button)sender;
            currentNumber += button.Content.ToString();
            Display.Text = currentNumber;
        }

        private void DecimalPoint_Click(object sender, RoutedEventArgs e)
        {
            if (newInput)
            {
                currentNumber = "0";
                newInput = false;
            }

            if (!currentNumber.Contains(","))
            {
                currentNumber += ",";
                Display.Text = currentNumber;
            }
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentNumber))
            {
                var button = (Button)sender;
                operation = button.Content.ToString();
                storedNumber = currentNumber;
                currentNumber = "";
                newInput = true;
            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(storedNumber) && !string.IsNullOrEmpty(operation) && !string.IsNullOrEmpty(currentNumber))
            {
                double result = 0;
                double a = double.Parse(storedNumber);
                double b = double.Parse(currentNumber);

                switch (operation)
                {
                    case "+": result = a + b; break;
                    case "-": result = a - b; break;
                    case "*": result = a * b; break;
                    case "/":
                        if (b != 0) result = a / b;
                        else
                        {
                            MessageBox.Show("Деление на ноль невозможно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        break;
                }

                AnimateDisplay();
                Display.Text = result.ToString();
                currentNumber = result.ToString();
                operation = "";
                newInput = true;
            }
        }

        private async void Clear_Click(object sender, RoutedEventArgs e)
        {
            // Анимация исчезновения
            var fadeOut = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = TimeSpan.FromSeconds(0.2)
            };

            Display.BeginAnimation(OpacityProperty, fadeOut);

            // Ждем завершения анимации
            await System.Threading.Tasks.Task.Delay(200);

            // Очищаем данные
            currentNumber = "";
            storedNumber = "";
            operation = "";
            Display.Text = "0";
            newInput = true;

            // Анимация появления
            var fadeIn = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = TimeSpan.FromSeconds(0.2)
            };

            Display.BeginAnimation(OpacityProperty, fadeIn);
        }

        private void AnimateDisplay()
        {
            var animation = new DoubleAnimation
            {
                From = 0.5,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.3)
            };

            var scaleTransform = new ScaleTransform();
            Display.RenderTransform = scaleTransform;
            scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, animation);
            scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, animation);
        }
    }
}