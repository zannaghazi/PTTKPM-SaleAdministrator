using System;
using DAO;
using DTO;

namespace BUS
{
    public class LoginBUS
    {
        public UserDAO userDAO;
        public LoginBUS()
        {
            userDAO = new UserDAO();
        }

        public UserDTO checkLogin(Connection connection, string username, string password)
        {
            if (String.IsNullOrWhiteSpace(username)
                || String.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            return this.userDAO.checkLogin(connection, username, password);
        }

    }
}
