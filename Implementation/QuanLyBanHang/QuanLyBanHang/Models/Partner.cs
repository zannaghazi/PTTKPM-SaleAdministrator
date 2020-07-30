using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Models
{
    public class Partner
    {
        public int ID;
        public string partner_name;
        public string infopost;
        public DateTime begindate;
        public DateTime deadline;
        public bool isDeleted;
      

        public Partner()
        {
            this.ID = -1;
            this.partner_name = null;
            this.infopost = null;
            this.begindate = DateTime.MinValue;
            this.deadline = DateTime.MinValue;
            this.isDeleted = false;
        }

        public Partner(int id, string name, DateTime begindate, DateTime deadline, string infopost )
        {
            this.ID = id;
            this.partner_name = name;
            this.infopost = infopost;
            this.begindate = begindate;
            this.deadline = deadline;
            this.isDeleted = false;
        }
    }

}
