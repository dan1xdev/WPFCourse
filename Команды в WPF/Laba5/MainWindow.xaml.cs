using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace SimpleNotepad
{
    public partial class MainWindow : Window
    {
        private string _currentFilePath;

        public MainWindow()
        {
            InitializeComponent();

            // Привязка команд
            CommandBindings.Add(new CommandBinding(ApplicationCommands.New, NewCommand_Executed));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Open, OpenCommand_Executed));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Save, SaveCommand_Executed));
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (TextArea.Text.Length > 0)
            {
                var result = MessageBox.Show(
                    "Сохранить изменения перед созданием нового файла?",
                    "Блокнот",
                    MessageBoxButton.YesNoCancel);

                if (result == MessageBoxResult.Yes)
                {
                    SaveFile();
                }
                else if (result == MessageBoxResult.Cancel)
                {
                    return;
                }
            }

            TextArea.Clear();
            _currentFilePath = null;
            Title = "Простой блокнот";
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*"
            };

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    TextArea.Text = File.ReadAllText(dialog.FileName);
                    _currentFilePath = dialog.FileName;
                    Title = $"Простой блокнот - {Path.GetFileName(_currentFilePath)}";
                }
                catch
                {
                    MessageBox.Show("Не удалось открыть файл", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFile();
        }

        private void SaveFile()
        {
            if (string.IsNullOrEmpty(_currentFilePath))
            {
                var dialog = new SaveFileDialog
                {
                    Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*"
                };

                if (dialog.ShowDialog() == true)
                {
                    _currentFilePath = dialog.FileName;
                }
                else
                {
                    return;
                }
            }

            try
            {
                File.WriteAllText(_currentFilePath, TextArea.Text);
                Title = $"Простой блокнот - {Path.GetFileName(_currentFilePath)}";
                MessageBox.Show("Файл успешно сохранен", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить файл", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (TextArea.Text.Length > 0)
            {
                var result = MessageBox.Show(
                    "Сохранить изменения перед выходом?",
                    "Блокнот",
                    MessageBoxButton.YesNoCancel);

                if (result == MessageBoxResult.Yes)
                {
                    SaveFile();
                }
                else if (result == MessageBoxResult.Cancel)
                {
                    return;
                }
            }

            Close();
        }
    }
}