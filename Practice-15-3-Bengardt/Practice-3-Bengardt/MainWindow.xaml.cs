﻿using System;
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
using Microsoft.Win32;

namespace Practice_3_Bengardt
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
        private int[,] _matrix;

        private void Create(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(columnOut.Text, out int column)) return;
            if (!int.TryParse(rowOut.Text, out int row)) return;
            if (column > 0 && row > 0)
            {
                _matrix = new int[row, column];
                dataGrid.ItemsSource = VisualArray.ToDataTable(_matrix).DefaultView;
                resultOut.Clear();
            }
        }

        private void MainOperation(object sender, RoutedEventArgs e)
        {
            if (_matrix == null) return;
            Practice.MaximumValueMatrix(_matrix, out string result);
            resultOut.Text = result;
        }
        private void FillDataGrid(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(numberMin.Text, out int minimum)) return;
            if (!int.TryParse(numberMax.Text, out int maximum)) return;
            if (!int.TryParse(columnOut.Text, out int column)) return;
            if (!int.TryParse(rowOut.Text, out int row)) return;
            if (maximum > minimum && column > 0 && row > 0)
            {
                _matrix = new int[row, column];
                LibMas.Matrix.RandomValues(_matrix, minimum, maximum);
                dataGrid.ItemsSource = VisualArray.ToDataTable(_matrix).DefaultView;
            }
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            
            int indexColumn = e.Column.DisplayIndex;
         
            int indexRow = e.Row.GetIndex();
          
            if (!int.TryParse(((TextBox)e.EditingElement).Text.Replace('.', ','), out int value))
            {
                MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
          
            _matrix[indexRow, indexColumn] = value;
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            LibMas.Matrix.Clear(_matrix);
            dataGrid.ItemsSource = VisualArray.ToDataTable(_matrix).DefaultView;
            columnOut.Clear();
            rowOut.Clear();
            numberMin.Clear();
            numberMax.Clear();
            resultOut.Clear();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Open(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Все файлы (*.*)|*.*|Текстовые файлы|*.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";
            if (open.ShowDialog() == true)
            {
                if (open.FileName != string.Empty)
                {
                    LibMas.Matrix.Open(open.FileName, out _matrix);
                    rowOut.Text = _matrix.GetLength(0).ToString();
                    columnOut.Text = _matrix.GetLength(1).ToString();
                    dataGrid.ItemsSource = VisualArray.ToDataTable(_matrix).DefaultView;
                }
            }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_matrix == null)
            {
                MessageBox.Show("Таблица пуста", "Ошибка");
                return;
            }
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*)|*.*|Текстовые файлы|*.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";
            if (save.ShowDialog() == true)
            {
                LibMas.Matrix.Save(save.FileName, _matrix);
            }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка!");
            }
        }
    }
}
