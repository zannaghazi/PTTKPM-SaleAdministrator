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
                    return null;
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
    }
}
