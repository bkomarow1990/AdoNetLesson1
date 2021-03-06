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
using System.Windows.Shapes;

namespace AdoNetLesson1
{
    /// <summary>
    /// Interaction logic for ShowBookWithAuthor.xaml
    /// </summary>
    public partial class ShowBookWithAuthor : Window
    {
        MainWindow mw;
        public ShowBookWithAuthor(MainWindow mw)
        {
            this.mw = mw;
            InitializeComponent();
        }

        private void showBtn_Click(object sender, RoutedEventArgs e)
        {
            
            try {
                itemsListBox.Items.Clear();
                string command = $"select b.Name from Books as b join BooksAuthors as ba on b.Id = ba.BookId join Authors as a on a.Id = ba.AuthorId where a.Name = @Author_Name";
                SqlCommand comm = new SqlCommand(command, DbConnect.connection);
                comm.Parameters.AddWithValue("@Author_Name", authorTxtBox.Text);
                mw.viewModel.db_connection.reader = comm.ExecuteReader();
                
                while (mw.viewModel.db_connection.reader.Read())
                {
                    for (int i = 0; i < mw.viewModel.db_connection.reader.FieldCount; i++)
                    {
                        itemsListBox.Items.Add(mw.viewModel.db_connection.reader.GetValue(i).ToString());
                    }
                    Console.WriteLine();
                }
                mw.viewModel.db_connection.reader.Close();
            }
            
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                mw.viewModel.db_connection.reader.Close();
            }
        }

    }
}
