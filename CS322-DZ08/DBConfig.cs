using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS322_DZ08
{
    public class DBConfig
    {
        private static string server = "localhost";
        private static string database = "cs322dz08";
        private static string username = "mihajlo";
        private static string password = "qwerty";

        static string conf = "server=" + server + ";username=" + username + ";password=" + password + ";database=" + database;

        static MySqlConnection db;

        public static MySqlConnection Connection
        {
            get
            {
                if (db == null)
                {
                    LazyInitializer.EnsureInitialized(ref db, CreateConnection);
                }
                return db;
            }
        }

        static MySqlConnection CreateConnection()
        {
            var db = new MySqlConnection(conf);
            db.Open();
            return db;
        }

        static void CloseConnection()
        {
            if (db != null)
            {
                db.Close();
                db.Dispose();
                db = null;
            }
        }

        public static void Init()
        {
            ExecuteQuery(" CREATE TABLE IF NOT EXISTS " + database + ".user (" +
                        " id INT NOT NULL AUTO_INCREMENT," +
                        " first_name VARCHAR(127) NOT NULL," +
                        " last_name VARCHAR(127) NOT NULL," +
                        " email VARCHAR(127) NOT NULL," +
                        " password VARCHAR(127) NOT NULL," +
                        " PRIMARY KEY (id)" +
                        " );");
        }

        public static void ExecuteQuery(string query)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(query, DBConfig.Connection);
            try
            {
                //MySqlDataReader reader = mySqlCommand.ExecuteReader();
                mySqlCommand.ExecuteNonQuery();
                DBConfig.CloseConnection();
                Console.WriteLine("Query has been successfully executed.");
            }
            catch (Exception ex)
            {
                DBConfig.CloseConnection();
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        public static void InsertUser(string firstName, string lastName, string email, string password)
        {
            ExecuteQuery("INSERT INTO "+database+".user (`first_name`, `last_name`, `email`, `password`) VALUES ('" + firstName + "', '" + lastName + "', '" + email + "', PASSWORD('" + password + "'))");
        }
    }
}