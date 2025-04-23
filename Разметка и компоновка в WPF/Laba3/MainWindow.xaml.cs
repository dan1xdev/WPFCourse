using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Laba3
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> Items { get; set; }
        private int _selectedIndex = -1;
        private const string NotesFilePath = "notes.txt";

        public MainWindow()
        {
            InitializeComponent();
            LoadNotes();
            this.DataContext = this;
            this.Closing += MainWindow_Closing;
        }

        private void LoadNotes()
        {
            Items = new ObservableCollection<string>();

            if (File.Exists(NotesFilePath)) //если файл существует
            {
                try
                {
                    var lines = File.ReadAllLines(NotesFilePath);
                    foreach (var line in lines)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            Items.Add(line);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке заметок: {ex.Message}");
                }
            }
        }

        private void SaveNotes()
        {
            try
            {
                File.WriteAllLines(NotesFilePath, Items);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении заметок: {ex.Message}");
            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveNotes();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedIndex = ListBox.SelectedIndex;
            MainTextField.Text = _selectedIndex >= 0 ? Items[_selectedIndex] : "";
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MainTextField.Text))
                return;

            Items.Add(MainTextField.Text);
            MainTextField.Text = "";
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedIndex >= 0)
            {
                Items[_selectedIndex] = MainTextField.Text;
            }
            MainTextField.Text = "";
            _selectedIndex = -1;
            ListBox.SelectedIndex = -1;
            SaveNotes(); // Сохраняем после изменения
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedIndex >= 0)
            {
                Items.RemoveAt(_selectedIndex);
                MainTextField.Text = "";
                _selectedIndex = -1;
                SaveNotes(); // Сохраняем после удаления
            }
        }

        private void MenuBtn_Click(object sender, RoutedEventArgs e)
        {
            // Можно добавить функционал меню
            MessageBox.Show("Меню приложения");
        }
    }
}