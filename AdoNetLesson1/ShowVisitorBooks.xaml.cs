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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        MainWindow mw = null;
        public Window1(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void showBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                itemsListBox.Items.Clear();
                string command = $"select b.Name from BooksVisitors as bv join Books as b on b.Id = bv.BookId join Visitors as v on v.Id = bv.VisitorId where v.Name = @Visitor_Name and v.Surname = @Visitor_Surname";
                SqlCommand comm = new SqlCommand(command, DbConnect.connection);
                comm.Parameters.AddWithValue("@Visitor_Name", visitorNameTxtBox.Text);
                comm.Parameters.AddWithValue("@Visitor_Surname", visitorNameTxtBox.Text);
                
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

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                mw.viewModel.db_connection.reader.Close();
            }
        }
    }
}
