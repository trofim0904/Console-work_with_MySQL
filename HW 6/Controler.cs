using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace HW_6
{
    class Controler
    {
        public static void Delete_User_by_ID(int deleteID)
        {
            try
            {
                MySqlConnection conn = DBWorker.getMysqlConnection();
                conn.Open();
                string query = $"DELETE FROM user WHERE user.id={deleteID}";
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = query;
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch { }
        }
        public static void Delete_User_by_Login(string login)
        {
            try
            {
                MySqlConnection conn = DBWorker.getMysqlConnection();
                conn.Open();
                string query = $"DELETE FROM user WHERE user.login={login}";
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = query;
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch { }
        }
        public static void Delete_Order_by_Number(string number)
        {
            try
            {
                MySqlConnection conn = DBWorker.getMysqlConnection();
                conn.Open();
                string query = $"DELETE FROM orders WHERE orders.number={number}";
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = query;
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch { }
        }
        public static void Delete_ORDER_by_ID(int deleteID)
        {
            try
            {
                
                MySqlConnection conn = DBWorker.getMysqlConnection();
                conn.Open();
                string query = $"DELETE FROM orders WHERE orders.id={deleteID}";
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = query;
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch { }
        }
        public static void Update_User_by_ID(int id,string name,string login,string password,string address,int age)
        {
            try
            {
                MySqlConnection conn = DBWorker.getMysqlConnection();
                conn.Open();
                string query = $"UPDATE user SET name='{name}',login='{login}',password='{password}',address='{address}',age={age} WHERE id={id}";
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = query;
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch { }
        }
        public static void Update_Order_by_ID(int id, string number, string type, string color, int user_id)
        {
            try
            {
                MySqlConnection conn = DBWorker.getMysqlConnection();
                conn.Open();
                string query = $"UPDATE orders SET number='{number}',type='{type}',color='{color}',user_id={user_id} WHERE id={id}";
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = query;
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch { }
        }
        public static void AddOrder(OrderModel order)
        {

                MySqlConnection conn = DBWorker.getMysqlConnection();
                conn.Open();
                string query = $"INSERT INTO user(name,login,password,address,age) VALUES('{order.user.name}','{order.user.login}','{order.user.password}','{order.user.address}',{order.user.age})";
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = query;
                command.ExecuteNonQuery();
                command = new MySqlCommand();
                query = $"SELECT id FROM user WHERE user.login='{order.user.login}'";
                command.Connection = conn;
        
                command.CommandText = query;
                int id_user = 0;
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        int idO = reader.GetOrdinal("id");
                        int id = Convert.ToInt32(reader.GetValue(idO));
                        id_user = id;
                    }

                }
                command = new MySqlCommand();
                query = $"INSERT INTO orders(number,type,color,user_id) VALUES('{order.number}','{order.type}','{order.color}',{id_user})";
                command.Connection = conn;
                command.CommandText = query;

                command.ExecuteNonQuery();
                conn.Close();
                 
            
        }

        public static void AddOrder(OrderModel order,UserModel userModel)
        {
            MySqlConnection conn = DBWorker.getMysqlConnection();
            conn.Open();
            string query = $"INSERT INTO orders(number,type,color,user_id) VALUES('{order.number}','{order.type}','{order.color}',{userModel.id})";
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = query;
            command.ExecuteNonQuery();
            conn.Close();
        }
        public void AddUser(UserModel user)
        {
            MySqlConnection conn = DBWorker.getMysqlConnection();
            conn.Open();

            string query = $"INSERT INTO user(name,login,password,address,age) VALUES('{user.name}','{user.login}','{user.password}','{user.address}',{user.age})";
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = query;
            command.ExecuteNonQuery();
            conn.Close();
        }
        public static List<UserModel> getListofUsers()
        {
            List<UserModel> userModels = new List<UserModel>();
            MySqlConnection conn = DBWorker.getMysqlConnection();
            conn.Open();
            string query = $"SELECT * FROM user";
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = query;
            using (DbDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UserModel userModel = new UserModel();
                        
                        int idO = reader.GetOrdinal("id");
                        int nameO = reader.GetOrdinal("name");
                        int loginO = reader.GetOrdinal("login");
                        int passwordO = reader.GetOrdinal("password");
                        int addressO = reader.GetOrdinal("address");
                        int ageO = reader.GetOrdinal("age");
                        int id = Convert.ToInt32(reader.GetValue(idO));
                        string name = reader.GetString(nameO);
                        string login = reader.GetString(loginO);
                        string password = reader.GetString(passwordO);
                        string address = reader.GetString(addressO);
                        int age = Convert.ToInt32(reader.GetValue(ageO));
                        
                        userModel.name = name;
                        userModel.login = login;
                        userModel.password = password;
                        userModel.address = address;
                        userModel.age = age;
                        userModel.id = id;
                        userModels.Add(userModel);
                    }

                }
            }
            conn.Close();
            return userModels;
        }    
        
        public static List<OrderModel> getListofOrders()
        {
            List<OrderModel> orderModels = new List<OrderModel>();
            MySqlConnection conn = DBWorker.getMysqlConnection();
            conn.Open();
            string query = $"SELECT * FROM orders";
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = query;
            using (DbDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrderModel orderModel = new OrderModel();

                        int idO = reader.GetOrdinal("id");
                        int numberO = reader.GetOrdinal("number");
                        int typeO = reader.GetOrdinal("type");
                        int colorO = reader.GetOrdinal("color");
                        
                        int user_idO = reader.GetOrdinal("user_id");
                        int id = Convert.ToInt32(reader.GetValue(idO));
                        string number = reader.GetString(numberO);
                        string type = reader.GetString(typeO);
                        string color = reader.GetString(colorO);
                        
                        int user_id = Convert.ToInt32(reader.GetValue(user_idO));
                        
                        orderModel.number = number;
                        orderModel.type = type;
                        orderModel.color = color;
                        orderModel.id = id;
                        orderModel.user = GetUser(user_id);
                        orderModels.Add(orderModel);
                    }

                }
            }
            conn.Close();
            return orderModels;
        }     
        public static OrderModel GetOrder(int id)
        {
            MySqlConnection conn = DBWorker.getMysqlConnection();
            OrderModel order = new OrderModel();
            
            conn.Open();

            string query = $"SELECT * FROM orders WHERE orders.id={id}";
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = query;
            using (DbDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int numberO = reader.GetOrdinal("number");
                        int typeO = reader.GetOrdinal("type");
                        int colorO = reader.GetOrdinal("color");
                        
                        int user_idO = reader.GetOrdinal("user_id");
                        
                        string number = reader.GetString(numberO);
                        string type = reader.GetString(typeO);
                        string color = reader.GetString(colorO);
                        
                        int user_id = Convert.ToInt32(reader.GetValue(user_idO));
                        
                        order.number = number;
                        order.type = type;
                        order.color = color;
                        order.id = id;
                        order.user = GetUser(user_id);
                    }

                }
            }
            conn.Close();
            return order;
        }
        public static UserModel GetUser(int id)
        {
            UserModel user = new UserModel();
            MySqlConnection conn = DBWorker.getMysqlConnection();
            conn.Open();

            string query = $"SELECT * FROM user WHERE user.id={id}";
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = query;
            using (DbDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        int nameO = reader.GetOrdinal("name");
                        int loginO = reader.GetOrdinal("login");
                        int passwordO = reader.GetOrdinal("password");
                        int addressO = reader.GetOrdinal("address");
                        int ageO = reader.GetOrdinal("age");
                        
                        string name = reader.GetString(nameO);
                        string login = reader.GetString(loginO);
                        string password = reader.GetString(passwordO);
                        string address = reader.GetString(addressO);
                        int age = Convert.ToInt32(reader.GetValue(ageO));
                        
                        user.name = name;
                        user.login = login;
                        user.password = password;
                        user.address = address;
                        user.age = age;
                        user.id = id;
                    }
                }
            }
            conn.Close();
            return user;
        }
    }
}
