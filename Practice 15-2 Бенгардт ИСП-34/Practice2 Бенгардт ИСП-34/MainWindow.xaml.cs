using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
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
using LibMas;
using Lib_13;

namespace Practice2_Бенгардт_ИСП_34
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private ThisArray _thisArray = new   ThisArray(5);

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void multiplication_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Calculation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                multiplication.Clear();
                multiplication.Text = _thisArray.MultiplicationOfMas();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка!");
            }
        }

       private void FillArray_Click(object sender, RoutedEventArgs e)
        {
            multiplication.Clear();
            _thisArray.Fill();
            dataGrid.ItemsSource = _thisArray.ToDataTable().DefaultView;
        }

        private void ClearArray_Click(object sender, RoutedEventArgs e)
        {
            _thisArray.Clear();
            multiplication.Clear();
            dataGrid.ItemsSource = _thisArray.ToDataTable().DefaultView;

        }
        private void OpenArray_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog.DefaultExt = ".txt";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Title = "Импорт массива";

            if (openFileDialog.ShowDialog() == true)
            {
                _thisArray.Import(openFileDialog.FileName);
            }
            multiplication.Clear();
            dataGrid.ItemsSource = _thisArray.ToDataTable().DefaultView;
        }

        private void SaveArray_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.Title = "Экспорт массива";

            if (saveFileDialog.ShowDialog() == true)
            {
                _thisArray.Export(saveFileDialog.FileName);
            }
            multiplication.Clear();
            dataGrid.ItemsSource = null;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

     
        }
        private void Information_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
