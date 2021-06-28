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
using System.Windows.Shapes;

namespace AdoNetLesson1
{
    /// <summary>
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        MainWindow mw;
        public AddBook(MainWindow mw)
        {
            this.mw = mw;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.BookName.Text != " ")
            {
                try { 
                    mw.viewModel.db_connection.command.CommandText = $"insert into Books(Name) values ('{BookName.Text}')";
                    mw.viewModel.db_connection.command.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MessageBox.Show("Added");
                return;
            }
            
        }
    }
}
