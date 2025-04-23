using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Laba8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _currentFilePath;
        private void changeLanguage(string cultureCode)
        {
            CultureInfo culture = new CultureInfo(cultureCode);
            ResourceManager rm = new ResourceManager("Laba8.Properties.Strings", typeof(MainWindow).Assembly);
            myWindow.Title = rm.GetString("WinTitle", culture);
            MainMenu.Header = rm.GetString("MainMenu", culture);
            SaveFileBtn.Header = rm.GetString("SaveFileBtn", culture);
            OpenFileBtn.Header = rm.GetString("OpenFileBtn", culture);
            NewFileBtn.Header = rm.GetString("NewFileBtn", culture);
            ExitBtn.Header = rm.GetString("ExitBtn", culture);
            EditMenu.Header = rm.GetString("EditMenu", culture);
            CopyBtn.Header = rm.GetString("CopyBtn", culture);
            PasteBtn.Header = rm.GetString("PasteBtn", culture);
            CutBtn.Header = rm.GetString("CutBtn", culture);
        }

        public MainWindow()
        {
            CommandBindings.Add(new CommandBinding(ApplicationCommands.New, NewCommand_Executed));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Open, OpenCommand_Executed));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Save, SaveCommand_Executed));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Copy, CopyCommand_Executed, CanExecuteCopyCut));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, PasteCommand_Executed, CanExecutePaste));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Cut, CutCommand_Executed, CanExecuteCopyCut));

            InitializeComponent();
        }

        private void CanExecuteCopyCut(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !string.IsNullOrEmpty(TextArea.SelectedText);
        }

        private void CanExecutePaste(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Clipboard.ContainsText();
        }

        private void CopyCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            TextArea.Copy();
        }

        private void PasteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            TextArea.Paste();
        }

        private void CutCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            TextArea.Cut();
        }

        private void myCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (myCombobox.SelectedItem is ComboBoxItem selectedItem)
            {
                string cultureCode = selectedItem.Tag.ToString();
                changeLanguage(cultureCode);
            }
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
                    Title = $"Простой блокнот - {System.IO.Path.GetFileName(_currentFilePath)}";
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
                Title = $"Простой блокнот - {System.IO.Path.GetFileName(_currentFilePath)}";
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