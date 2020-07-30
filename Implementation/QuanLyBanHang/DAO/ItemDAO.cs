using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using DTO;

namespace DAO
{
    public class ItemDAO
    {
        public ItemDAO()
        {

        }
        public List<ItemDTO> getAllItem(Connection conn)
        {
            List<ItemDTO> result = new List<ItemDTO>();

            string queryString = "select* from Item where isDeleted = false";
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
                        ItemDTO temp = new ItemDTO(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetInt64(3),
                            reader.GetInt64(4),
                            reader.GetString(5),
                            reader.GetBoolean(6));
                        result.Add(temp);
                    }

                }
            }

            return result;
        }

        public ItemDTO getItemByID(Connection conn, int id)
        {
            string queryString = "select* from Item where id=" + id;
            conn.cmd.CommandText = queryString;

            using (DbDataReader reader = conn.cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    return new ItemDTO();
                }
                else
                {
                    ItemDTO temp = new ItemDTO();
                    while (reader.Read())
                    {
                        temp = new ItemDTO(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetInt64(3),
                            reader.GetInt64(4),
                            reader.GetString(5),
                            reader.GetBoolean(6));
                        break;
                    }
                    return temp;
                }
            }
        }

        public List<ItemDTO> AddItem(Connection conn, ItemDTO sp)
        {
            List<ItemDTO> result = new List<ItemDTO>();
            string queryString = "insert into Item(name, type, amount, minimum, provider, isRequestImport, isDeleted) " +
                "values('" + sp.name +
                "', '" + sp.type +
                "', " + sp.amount +
                ", " + sp.minimum +
                ", '" + sp.provider +
                "', false, false)";
            conn.cmd.CommandText = queryString;
            try
            {
                conn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            queryString = "select* from Item order by id desc limit 1";
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
                        ItemDTO temp = new ItemDTO(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetInt64(3),
                            reader.GetInt64(4),
                            reader.GetString(5),
                            reader.GetBoolean(6));
                        result.Add(temp);
                    }
                }
            }
            return result;
        }

        public bool UpdateItem(Connection conn, ItemDTO sp)
        {
            string queryString = "update Item set name='" + sp.name +
                "',type='" + sp.type +
                "',amount=" + sp.amount +
                ",minimum=" + sp.minimum +
                ",provider='" + sp.provider +
                "',isRequestImport=" + sp.isImportOrder.ToString() +
                " where id=" + sp.ID;
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

        public bool DeleteItem(Connection conn, ItemDTO sp)
        {
            string queryString = "update Item set isDeleted=true where id=" + sp.ID;
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
    }
}
