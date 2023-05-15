
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G
{
    public class DbParameter
    {
        public String name;
        public Object value;
    }
    class Sqlconnect
    {
        public static MySqlConnection getconfig() //Подключение к бд
        {
            string host = Properties.Settings.Default.host;
            int port = Properties.Settings.Default.port;
            string database = Properties.Settings.Default.database;
            string username = Properties.Settings.Default.username;
            string password = Properties.Settings.Default.password;
            //Выше конфиг Базы Данных
            string connString = "Server=" + host + ";Database=" + database + ";port=" + port + ";User Id=" + username + ";password=" + password + ";convert zero datetime=True";
            //Объединяем конфиг
            MySqlConnection conn = new MySqlConnection(connString);
            // И загружаем в переменную конфиг
            return conn;

        }  //---------------------------------------------
        public static int getscalar(String sql, List<DbParameter> parameters)
        {
            MySqlConnection connect = getconfig();

            MySqlCommand command = new MySqlCommand(sql, connect);
            foreach (DbParameter item in parameters)
            {
                command.Parameters.AddWithValue(item.name, item.value);
            }

            connect.Open();


            return Convert.ToInt32(command.ExecuteScalar());

        }

        public static DataTable select(String sql, List<DbParameter> parameters)
        {
            MySqlConnection connect = getconfig();

            MySqlCommand command = new MySqlCommand(sql, connect);
            foreach (DbParameter item in parameters)
            {
                command.Parameters.AddWithValue(item.name, item.value);
            }

            connect.Open();
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());

            return table;
        }
        public static bool TestCon()
        {
            MySqlConnection conn = new MySqlConnection();
            try
            {
                conn = getconfig();
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
