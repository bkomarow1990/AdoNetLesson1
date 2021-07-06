using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace AdoNetLesson1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ApplicationViewModel viewModel = new ApplicationViewModel();
        
        public MainWindow()
        {

            InitializeComponent();
        }

        private void addBook_btn_Click(object sender, RoutedEventArgs e)
        {
            AddBook addBook = new AddBook(this);
            addBook.ShowDialog();
        }

        private void getCountVisitorsBtn_Click(object sender, RoutedEventArgs e)
        {
            viewModel.db_connection.command.CommandText = "select count(v.id) from Visitors as v";
            MessageBox.Show( viewModel.db_connection.command.ExecuteScalar().ToString());
        }

        private void showDebtorsBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand comm = new SqlCommand("select * from Visitors as v where v.IsDebtor = @isDebtor", DbConnect.connection);
            comm.Parameters.AddWithValue("@isDebtor", 1);
            viewModel.db_connection.reader = comm.ExecuteReader();

            string str="==========================================";
            if (!viewModel.db_connection.reader.HasRows)
            {
                MessageBox.Show("Haven`t");
                viewModel.db_connection.reader.Close();
                return;
            }
            while (viewModel.db_connection.reader.Read())
            {
                for (int j = 0; j < viewModel.db_connection.reader.FieldCount; j++)
                {
                    str += "\n" + (viewModel.db_connection.reader.GetValue(j).ToString());
                }
                
                str+= "\n==========================================";
            }
            viewModel.db_connection.reader.Close();
            MessageBox.Show(str);
        }

        private void showAuthorsWithBookName_Click(object sender, RoutedEventArgs e)
        {
            ShowBookWithAuthor showBookWithAuthor = new ShowBookWithAuthor(this);
            showBookWithAuthor.ShowDialog();
        }

        private void showVisitorBooks_Click(object sender, RoutedEventArgs e)
        {
            Window1 ShowVisitorBooks = new Window1(this);
            ShowVisitorBooks.ShowDialog();
        }

        private void clearAllDebtsBtn_Click(object sender, RoutedEventArgs e)
        {
            viewModel.db_connection.command.CommandText = "update Visitors set IsDebtor = 0";
            viewModel.db_connection.command.ExecuteNonQuery();
            MessageBox.Show("All debts were cleared");
        }
    }
}
