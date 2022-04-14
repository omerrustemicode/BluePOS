using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace TestProject.myclass
{
    class connections
    {
        MySqlConnection conn;
        public connections(string connectionString)
        {
            conn = new MySqlConnection(connectionString);
        }
        public bool isConnection
        {
            get
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                return true;
            }
        }
    }
}
