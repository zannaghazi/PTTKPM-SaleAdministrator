using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Models
{
    public class Comment
    {
        public int ID;
        public int productID;
        public string email;
        public int status;
        public string detail;

        public Comment(int iD, int productID, string email, int status, string detail)
        {
            ID = iD;
            this.productID = productID;
            this.email = email;
            this.status = status;
            this.detail = detail;
        }
    }
}
