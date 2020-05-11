using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QuanLyBanHang.Repository
{
    public class Repository
    {
        public MySqlConnection conn = new MySqlConnection();
        public MySqlCommand cmd = new MySqlCommand();

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
            } catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Không thể kết nối với cơ sở dữ liệu!\nChi tiết: " + ex.StackTrace,
                    "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}
