using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DTO
{
    public class UserDTO
    {
        public int ID;
        public string userName;
        public string password;
        public string name;
        public int role;

        /// <summary>
        /// Constructor for null user
        /// </summary>
        public UserDTO()
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
        public UserDTO(int ID, string userName, string password, string name, int role)
        {
            this.ID = ID;
            this.userName = userName;
            this.password = password;
            this.name = name;
            this.role = role;
        }
    }
}
