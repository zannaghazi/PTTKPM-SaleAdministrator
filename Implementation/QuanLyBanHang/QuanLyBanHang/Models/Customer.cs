using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Models
{
    /// <summary>
    /// Model of Customer
    /// </summary>
    public class Customer
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
        public Customer()
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
        public Customer(int iD, string name, string email, string address, int point, bool isBanned)
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
