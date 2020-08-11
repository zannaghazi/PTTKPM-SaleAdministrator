using System;
using System.Collections.Generic;
using DTO;
using System.Text;
using System.Data.Common;

namespace DAO
{
    public class ItemOrderDAO
    {
        public List<ItemOrderDTO> getAllItemOrder(Connection conn)
        {
            List<ItemOrderDTO> result = new List<ItemOrderDTO>();
            string queryString = "select* from ItemOrder where isApproved = false and isDeleted = false";
            conn.cmd.CommandText = queryString;

            using (DbDataReader reader = conn.cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    return new List<ItemOrderDTO>();
                }
                else
                {
                    while (reader.Read())
                    {
                        ItemOrderDTO temp = new ItemOrderDTO(
                            reader.GetInt32(0),
                            reader.GetDateTime(1),
                            reader.GetString(2),
                            reader.GetInt32(3),
                            reader.GetString(4),
                            reader.GetBoolean(5));
                        result.Add(temp);
                    }

                }
            }
            for (int i = 0; i < result.Count; i++)
            {
                string[] listSPID = result[i].listItemID.Trim().Split(' ');
                List<ItemDTO> listOrderItem = new List<ItemDTO>();
                for (int j = 0; j < listSPID.Length; j++)
                {
                    ItemDAO itemDAO = new ItemDAO();
                    if (itemDAO.getItemByID(conn, Convert.ToInt32(listSPID[j])).ID != -1)
                    {
                        listOrderItem.Add(itemDAO.getItemByID(conn, Convert.ToInt32(listSPID[j])));
                    }
                }
                result[i].listSP = listOrderItem;
            }

            return result;
        }

        public bool UpdateItemOrder(Connection conn, ItemOrderDTO data)
        {
            string queryString = "update ItemOrder set owner='" + data.owner +
                    "',type=" + data.type +
                    ",listItem='" + data.listItemID +
                    "',isApproved=" + data.isApproved.ToString() +
                    " where id=" + data.ID;
            Console.WriteLine(queryString);
            conn.cmd.CommandText = queryString;
            try
            {
                conn.cmd.ExecuteNonQuery();
                for (int i = 0; i < data.listSP.Count; i++)
                {
                    ItemDAO itemDAO = new ItemDAO();
                    data.listSP[i].isImportOrder = false;
                    itemDAO.UpdateItem(conn, data.listSP[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            return true;
        }

        public bool DeleteItemOrder(Connection conn, ItemOrderDTO data)
        {
            string queryString = "update ItemOrder set isDeleted=true where id=" + data.ID;
            Console.WriteLine(queryString);
            conn.cmd.CommandText = queryString;
            try
            {
                conn.cmd.ExecuteNonQuery();
                for (int i = 0; i < data.listSP.Count; i++)
                {
                    ItemDAO itemDAO = new ItemDAO();
                    data.listSP[i].isImportOrder = false;
                    itemDAO.UpdateItem(conn, data.listSP[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            return true;
        }

        public bool AddItemOrder(Connection conn, ItemOrderDTO data)
        {
            string queryString = "";
            for (int i = 0; i < data.listSP.Count; i++)
            {
                ItemDAO itemDAO = new ItemDAO();
                data.listSP[i].isImportOrder = true;
                itemDAO.UpdateItem(conn, data.listSP[i]);
            }
            queryString = "insert into ItemOrder(createddate, owner, type, listItem, isApproved) " +
                "values('" + String.Format("{0:yyyy/MM/dd}", DateTime.Now) + "'," +
                "'" + data.owner + "'," +
                data.type + "," +
                "'" + this.BuildListIDString(data.listSP) + "'" +
                ", false)";
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

        public List<ItemOrderDTO>  LoadApprovedImport(Connection conn)
        {
            List<ItemOrderDTO> temp = new List<ItemOrderDTO>();
            string queryString = "select* from ItemOrder where isApproved = true and isDeleted = false";
            conn.cmd.CommandText = queryString;

            using (DbDataReader reader = conn.cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    return new List<ItemOrderDTO>();
                }
                else
                {
                    while (reader.Read())
                    {
                        ItemOrderDTO data = new ItemOrderDTO(
                            reader.GetInt32(0),
                            reader.GetDateTime(1),
                            reader.GetString(2),
                            reader.GetInt32(3),
                            reader.GetString(4),
                            reader.GetBoolean(5));
                        temp.Add(data);
                    }

                }
            }
            return temp;
        }
    }
}
