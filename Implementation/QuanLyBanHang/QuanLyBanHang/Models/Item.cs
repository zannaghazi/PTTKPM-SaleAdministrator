using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Models
{
    public class Item
    {
        public int ID;
        public string name;
        public string type;
        public long amount;
        public long minimum;

        /// <summary>
        /// Constructor without parameter
        /// </summary>
        public Item()
        {
            this.ID = -1;
            this.name = null;
            this.type = null;
            this.amount = -1;
            this.minimum = -1;
        }

        /// <summary>
        /// Constructor with params
        /// </summary>
        /// <param name="id">The item's ID</param>
        /// <param name="name">The item's name</param>
        /// <param name="type">Type of item</param>
        /// <param name="amount">Storage item</param>
        /// <param name="minimum">Limit of item</param>
        public Item(int id, string name, string type, long amount, long minimum)
        {
            this.ID = id;
            this.name = name;
            this.type = type;
            this.amount = amount;
            this.minimum = minimum;
        }
    }
}
