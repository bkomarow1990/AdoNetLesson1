using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace AdoNetLesson1
{
    public class DbConnect
    {
        static public string connection_string;
        static public SqlConnection connection;
        public SqlDataReader reader;
        public SqlCommand command;
        public DbConnect()
        {
            connection_string = ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString;
            connection = new SqlConnection(connection_string);
            command = new SqlCommand("select * from", connection);
        }
    }
}
