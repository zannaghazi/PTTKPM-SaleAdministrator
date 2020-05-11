using System;
using System.Collections.Generic;
using System.Data.Common;
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
        public User checkLogin(Repository.Repository repository, string username, string password)
        {
            // Using username to query from DB
            string queryString = "select* from User where username='" + username +
                "' and isDeleted=false";
            repository.cmd.CommandText = queryString;

            using (DbDataReader reader = repository.cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    return new User();
                }
                else
                {
                    User temp = new User();
                    while (reader.Read())
                    {
                        temp = new User(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetInt32(4));
                        break;
                    }
                    if (temp.password != password)
                    {
                        return new User();
                    }
                    return temp;
                }
            }
        }
    }
}
