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
                mw.viewModel.db_connection.command.CommandText = $"select b.Name from Books as b join BooksAuthors as ba on b.Id = ba.BookId join Authors as a on a.Id = ba.AuthorId where a.Name = '{authorTxtBox.Text}'";
                mw.viewModel.db_connection.reader = mw.viewModel.db_connection.command.ExecuteReader();
                while (mw.viewModel.db_connection.reader.Read())
                {
                    for (int i = 0; i < mw.viewModel.db_connection.reader.FieldCount; i++)
                    {
                        itemsListBox.Items.Add(mw.viewModel.db_connection.reader.GetValue(i).ToString());
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
