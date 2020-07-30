using System;
using System.Data.Common;
using DTO;

namespace DAO
{
    public class UserDAO
    {
        public UserDAO()
        {

        }

        /// <summary>
        /// Check login information
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>user's data if user exist</returns>
        /// <returns>null user if user doesn't exist</returns>
        public UserDTO checkLogin(Connection repository, string username, string password)
        {
            // Using username to query from DB
            string queryString = "select* from User where username='" + username +
                "' and isDeleted=false";
            repository.cmd.CommandText = queryString;

            using (DbDataReader reader = repository.cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    return new UserDTO();
                }
                else
                {
                    UserDTO temp = new UserDTO();
                    while (reader.Read())
                    {
                        temp = new UserDTO(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetInt32(4));
                        break;
                    }
                    if (temp.password != password)
                    {
                        return new UserDTO();
                    }
                    return temp;
                }
            }
        }
    }
}
