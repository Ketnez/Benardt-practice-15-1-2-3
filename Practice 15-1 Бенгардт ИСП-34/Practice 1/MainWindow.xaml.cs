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
using Lib13;

namespace Practice_1
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

        private void Calculating_Click(object sender, RoutedEventArgs e)
     

        {
            try
            {
                var results = Practice.CalculatingNumbers();
                result.Text = results.ToString();

                numbers.Text = result.numbers;

                result.Text = result.results;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка!");
            }
        }
    
   

       

    }
}
