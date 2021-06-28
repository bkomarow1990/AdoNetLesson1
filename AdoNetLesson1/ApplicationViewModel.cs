using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdoNetLesson1
{
    public class ApplicationViewModel
    {
        public DbConnect db_connection;
        private void InitConnections()
        {
            try
            {
                db_connection = new DbConnect();
                DbConnect.connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DbError", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public ApplicationViewModel()
        {
            InitConnections();
        }
    }
}
