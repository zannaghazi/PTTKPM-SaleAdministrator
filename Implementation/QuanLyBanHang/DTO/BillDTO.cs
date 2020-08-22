using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class BillDTO
    {
        public int ID;
        public DateTime date;
        public string customerName;
        public string salerName;
        public List<ItemDTO> products;
        public List<ItemDTO> defectiveProducts;

        public string productsID;
        public string defectiveProductsID;

        public BillDTO()
        {
            this.ID = -1;
            this.date = DateTime.Now;
        }

        public BillDTO(int id, DateTime date, string customerName, string salerName, List<ItemDTO> pros, List<ItemDTO> defPros)
        {
            this.ID = id;
            this.date = date;
            this.customerName = customerName;
            this.salerName = salerName;
            this.products = pros;
            this.defectiveProducts = defPros;
        }

        public BillDTO(int id, DateTime date, string customerName, string salerName, string prosID, string defProsID)
        {
            this.ID = id;
            this.date = date;
            this.customerName = customerName;
            this.salerName = salerName;
            this.productsID = prosID;
            this.defectiveProductsID = defProsID;
        }
    }
}
