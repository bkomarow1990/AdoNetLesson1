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
            viewModel.db_connection.command.CommandText = "select * from Visitors as v where v.IsDebtor = 1";
            viewModel.db_connection.reader = viewModel.db_connection.command.ExecuteReader();

            string str="==========================================";
            while (viewModel.db_connection.reader.Read())
            {
                for (int j = 0; j < viewModel.db_connection.reader.FieldCount; j++)
                {
                    str += "\n" + (viewModel.db_connection.reader.GetValue(j).ToString());
                }
                
                str+= "\n==========================================";
            }
            MessageBox.Show(str);
        }

        private void showAuthorsWithBookName_Click(object sender, RoutedEventArgs e)
        {
            ShowBookWithAuthor showBookWithAuthor = new ShowBookWithAuthor(this);
            showBookWithAuthor.ShowDialog();
        }
    }
}
