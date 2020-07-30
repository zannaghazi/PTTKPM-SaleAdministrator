using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO
{
    public class Connection
    {
        public MySqlConnection conn = new MySqlConnection();
        public MySqlCommand cmd = new MySqlCommand();

        public Connection()
        {
            this.InitDBConnection();
        }
        public void InitDBConnection()
        {
            string[] config = System.IO.File.ReadAllLines("config.txt");

            String sqlString = config[0];
            this.conn = new MySqlConnection(sqlString);

            try
            {
                Console.WriteLine("Connecting DB...");
                this.conn.Open();
                this.cmd.Connection = this.conn;
                Console.WriteLine("Connect to DB success!");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
