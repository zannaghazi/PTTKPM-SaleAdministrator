using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Models
{
    public class QangCaoSDT
    {
        public int ID;
        public int id_customer;
        public int id_item;
        public DateTime dateqc;
        public string sdt_customer;
        public string name_customer;

        public QangCaoSDT()
        {
            this.ID = -1;
            this.id_customer = -1;
            this.id_item = -1;
            this.dateqc = DateTime.MinValue;

        }

        public QangCaoSDT(int id, int id_customer, int id_item, DateTime dateqc)
        {
            this.ID = id;
            this.id_customer = id_customer;
            this.id_item = id_item;
            this.dateqc = dateqc;
        }
        public QangCaoSDT(int id, int id_customer, string sdt_customer, int id_item, DateTime dateqc)
        {
            this.ID = id;
            this.sdt_customer = sdt_customer;
            this.id_item = id_item;
            this.dateqc = dateqc;
        }
        public QangCaoSDT(int id,int id_customer, string sdt_customer, string name_customer)
        {
            this.ID = id;
            this.sdt_customer = sdt_customer;
            this.name_customer = name_customer;
         
        }
    }
}
