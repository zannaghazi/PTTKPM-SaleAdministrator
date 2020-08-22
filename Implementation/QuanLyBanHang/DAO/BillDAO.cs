using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using DTO;

namespace DAO
{
    public class BillDAO
    {
        public BillDAO()
        {
        }

        public BillDTO getBillByID(Connection conn, int id)
        {
            string queryString = "select * from bill where id=" + id;
            conn.cmd.CommandText = queryString;

            using (DbDataReader reader = conn.cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    return new BillDTO();
                }
                else
                {
                    BillDTO temp = new BillDTO();
                    while (reader.Read())
                    {
                        temp = new BillDTO(
                            reader.GetInt32(0),
                            reader.GetDateTime(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(5),
                            reader.GetString(6));
                        break;
                    }
                    string[] listPID = temp.productsID.Trim().Split(' ');
                    string[] listDPID = temp.defectiveProductsID.Trim().Split(' ');
                    List<ItemDTO> items = new List<ItemDTO>();
                    for (int j = 0; j < listPID.Length; j++)
                    {
                        ItemDAO itemDAO = new ItemDAO();
                        if (itemDAO.getItemByID(conn, Convert.ToInt32(listPID[j])).ID != -1)
                        {
                            temp.products.Add(itemDAO.getItemByID(conn, Convert.ToInt32(listPID[j])));
                        }
                    }
                    for (int j = 0; j < listDPID.Length; j++)
                    {
                        ItemDAO itemDAO = new ItemDAO();
                        if (itemDAO.getItemByID(conn, Convert.ToInt32(listDPID[j])).ID != -1)
                        {
                            temp.defectiveProducts.Add(itemDAO.getItemByID(conn, Convert.ToInt32(listDPID[j])));
                        }
                    }
                    return temp;
                }
            }
        }

        public bool addBill(Connection conn, BillDTO data)
        {
            string queryString = "";
            queryString = "insert into bill(exportDate, customer, saler, productsID, defectiveProductsID) " +
                "values(" +
                "'" + String.Format("{0:yyyy/MM/dd}", data.date) + "'," +
                "'" + data.customerName + "'," +
                "'" + data.salerName + "'," +
                "'" + this.BuildListIDString(data.products) + "'" +
                "'" + this.BuildListIDString(data.defectiveProducts) + "'" +
                ")";
            Console.WriteLine(queryString);
            conn.cmd.CommandText = queryString;
            try
            {
                conn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            return true;
        }

        public static bool deleteBill(Connection conn, BillDTO data)
        {
            string queryString = "delete from Bill where id=" + data.ID;
            Console.WriteLine(queryString);
            conn.cmd.CommandText = queryString;
            try
            {
                conn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            return true;
        }

        public bool updateBill(Connection conn, BillDTO data)
        {
            string queryString = "update Bill set exportDate='" + data.date +
                    "',customer=" + data.customerName +
                    ",saler='" + data.salerName +
                    ",productsID='" + this.BuildListIDString(data.products) +
                    ",defectiveProductsID='" + this.BuildListIDString(data.defectiveProducts) +
                    " where id=" + data.ID;
            Console.WriteLine(queryString);
            conn.cmd.CommandText = queryString;
            try
            {
                conn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            return true;
        }

        public string BuildListIDString(List<ItemDTO> data)
        {
            string temp = "";
            for (int i = 0; i < data.Count; i++)
            {
                temp += data[i].ID + " ";
            }
            return temp;
        }
    }
}
