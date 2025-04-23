using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace GuessNumberGame
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private int _secretNumber;
        private int _attempts;
        private string _userInput;
        private string _resultMessage;
        private readonly Random _random = new Random();

        // Свойства для привязки
        public string HintText { get; } = "Угадайте число от 1 до 100";
        public string AttemptsText => $"Попыток: {Attempts}";

        public string UserInput
        {
            get => _userInput;
            set
            {
                _userInput = value;
                OnPropertyChanged(nameof(UserInput));
            }
        }

        public string ResultMessage
        {
            get => _resultMessage;
            set
            {
                _resultMessage = value;
                OnPropertyChanged(nameof(ResultMessage));
            }
        }

        public int Attempts
        {
            get => _attempts;
            set
            {
                _attempts = value;
                OnPropertyChanged(nameof(Attempts));
                OnPropertyChanged(nameof(AttemptsText));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            StartNewGame();
        }

        private void StartNewGame()
        {
            _secretNumber = _random.Next(1, 101);
            Attempts = 0;
            UserInput = "";
            ResultMessage = "";
        }

        private void CheckNumber()
        {
            if (!int.TryParse(UserInput, out int guess))
            {
                ResultMessage = "Введите число!";
                return;
            }

            if (guess < 1 || guess > 100)
            {
                ResultMessage = "Число должно быть от 1 до 100!";
                return;
            }

            Attempts++;

            if (guess < _secretNumber)
                ResultMessage = "Слишком маленькое!";
            else if (guess > _secretNumber)
                ResultMessage = "Слишком большое!";
            else
                ResultMessage = $"Поздравляем! Вы угадали за {Attempts} попыток!";
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e) => CheckNumber();
        private void NewGameButton_Click(object sender, RoutedEventArgs e) => StartNewGame();

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}