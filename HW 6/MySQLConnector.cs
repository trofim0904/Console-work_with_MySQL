using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW_6
{
    class MySQLConnector
    {
        public static MySqlConnection getConnection(string host, int port, string db, string username, string password)
        {
            String config = "Server=" + host + ";Database=" + db + ";port=" + port + ";User Id=" + username + ";password=" + password;
            MySqlConnection conn = new MySqlConnection(config);
            return conn;
        }
    }
}
