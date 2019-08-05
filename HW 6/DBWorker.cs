using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW_6
{
    class DBWorker
    {
        static string host = "127.0.0.1";
        static int port = 3306;
        static string db = "users";
        static string username = "root";
        static string password = "";

        public static MySqlConnection getMysqlConnection()
        {
            return MySQLConnector.getConnection(host, port, db, username, password);
        }
    }
}
