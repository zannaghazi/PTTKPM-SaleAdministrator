using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Windows.Forms;
using DAO;
using DTO;

namespace BUS
{
    public class QuanLyDatHangBUS
    {
        public BillDAO billDAO;
        public BillDTO billDTO;

        public QuanLyDatHangBUS()
        {
            billDAO = new BillDAO();
            billDTO = new BillDTO();
        }

        public BillDTO loadBillByID(Connection conn, int id)
        {
            return this.billDAO.getBillByID(conn, id);
        }

        public void billConstruction(Connection conn, string customer, string saler, List<ItemDTO> pros, List<ItemDTO> defPros)
        {
            this.billDTO.defectiveProducts = defPros;
            this.billDTO.products = pros;
            this.billDTO.customerName = customer;
            this.billDTO.salerName = saler;
            this.billDTO.date = DateTime.Now;
            this.billDAO.updateBill(conn, billDTO);
        }
    }
}

