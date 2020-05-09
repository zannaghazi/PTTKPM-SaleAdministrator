using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Models
{
    /// <summary>
    /// Class define data type for table User
    /// </summary>
    public class User
    {
        public int ID;
        public string userName;
        public string password;
        public string name;
        public int role;

        /// <summary>
        /// Constructor for null user
        /// </summary>
        public User()
        {
            this.ID = -1;
            this.userName = null;
            this.password = null;
            this.name = null;
            this.role = -1;
        }

        /// <summary>
        /// Constructor with full user data
        /// </summary>
        /// <param name="ID">The user's ID</param>
        /// <param name="userName">The username</param>
        /// <param name="password">The account password</param>
        /// <param name="name">The user's name</param>
        /// <param name="role">The user's role</param>
        public User(int ID, string userName, string password, string name, int role)
        {
            this.ID = ID;
            this.userName = userName;
            this.password = password;
            this.name = name;
            this.role = role;
        }

        /// <summary>
        /// Check login information
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>user's data if user exist</returns>
        /// <returns>null user if user doesn't exist</returns>
        public User checkLogin(string username, string password)
        {
            // Using username to query from DB

            // DUMMY DATA:
            User quanly = new User(1, "admin", "admin", "Quan Ly", 0);
            User banhang = new User(2, "banhang", "banhang", "Nhan Vien Ban Hang", 1);

            // Check username and password is correct or not

            if (username == quanly.userName && password == quanly.password)
            {
                return quanly;
            }else if (username == banhang.userName && password == banhang.password)
            {
                return banhang;
            }
            return new User();
        }
    }
}
