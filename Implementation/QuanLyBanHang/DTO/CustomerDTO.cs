using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class CustomerDTO
    {
        public int ID;
        public string name;
        public string email;
        public string address;
        public int point;
        public bool isBanned;

        /// <summary>
        /// Constructor
        /// </summary>
        public CustomerDTO()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="iD">Id of customer</param>
        /// <param name="name">name of customer</param>
        /// <param name="email">email of customer</param>
        /// <param name="address">address of customer</param>
        /// <param name="isBanned">is banned or not</param>
        public CustomerDTO(int iD, string name, string email, string address, int point, bool isBanned)
        {
            ID = iD;
            this.name = name;
            this.email = email;
            this.address = address;
            this.point = point;
            this.isBanned = isBanned;
        }
    }
}
