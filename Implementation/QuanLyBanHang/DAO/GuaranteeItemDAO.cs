using DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DAO
{
    public class GuaranteeItemDAO
    {
        public GuaranteeItemDAO()
        {

        }

        public bool AddNewGuaranteeItem(Connection conn, GuaranteeItemDTO item)
        {
            string query = "Insert into GuaranteeItem (createdUser, itemId, provider, status, reason, isApproved)" +
                "values (" + item.createdUser +
                ", " + item.itemID +
                ", '" + item.provider +
                "', '" + item.stats +
                "', '" + item.reason +
                "', " + item.isApproved.ToString() +")";
            
            conn.cmd.CommandText = query;

            try
            {
                conn.cmd.ExecuteNonQuery();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            return true;
        }

        public bool ApproveGuaranteeItem(Connection conn, int id)
        {
            string query = "Update GuaranteeItem set isApproved = true " +
                "where id = " + id;
            conn.cmd.CommandText = query;

            try
            {
                conn.cmd.ExecuteNonQuery();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            return true;
        }

        public bool DeleteGuaranteeItem(Connection conn, int id)
        {
            string query = "Update GuaranteeItem set isDeleted = true " +
                "where id = " + id;
            conn.cmd.CommandText = query;

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

        public List<GuaranteeItemDTO> findItemByProvider(Connection conn, string provider)
        {
            List<GuaranteeItemDTO> result = new List<GuaranteeItemDTO>();

            string query = "Select * from GuaranteeItem where isDeleted = false and isApproved = false and provider like '" + provider.Trim() + "'";
            Console.WriteLine(query);
            conn.cmd.CommandText = query;

            using (DbDataReader reader = conn.cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    return new List<GuaranteeItemDTO>();
                }
                else
                {
                    while (reader.Read())
                    {
                        GuaranteeItemDTO temp = new GuaranteeItemDTO(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetInt32(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5),
                            reader.GetBoolean(6),
                            reader.GetBoolean(7));
                        result.Add(temp);
                    }

                }
            }
            return result;
        }
    }
}
