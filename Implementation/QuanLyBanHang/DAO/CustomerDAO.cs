using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using DTO;

namespace DAO
{
    public class CustomerDAO
    {
        public CustomerDAO()
        {

        }

        /// <summary>
        /// GetAllCustomer
        /// </summary>
        /// <param name="conn">Connection</param>
        /// <returns></returns>
        public static List<CustomerDTO> getAllCustomer(Connection conn)
        {
            List<CustomerDTO> result = new List<CustomerDTO>();

            string queryString = "select * from Customer";
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
                        CustomerDTO temp = new CustomerDTO(
                             reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetInt32(4),
                            reader.GetBoolean(5));
                        result.Add(temp);
                    }

                }
            }

            return result;
        }

        /// <summary>
        /// Single customer by id
        /// </summary>
        /// <param name="conn">Connection</param>
        /// <param name="id">id customer</param>
        /// <returns></returns>
        public static CustomerDTO singleByID(Connection conn, int id)
        {
            string queryString = "select* from customer where id=" + id;
            conn.cmd.CommandText = queryString;

            using (DbDataReader reader = conn.cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    return new CustomerDTO();
                }
                else
                {
                    CustomerDTO temp = new CustomerDTO();
                    while (reader.Read())
                    {
                        temp = new CustomerDTO(
                             reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetInt32(4),
                            reader.GetBoolean(5));
                        break;
                    }
                    return temp;
                }
            }
        }

        /// <summary>
        /// Update custommer
        /// </summary>
        /// <param name="conn">connection</param>
        /// <param name="customer">customer update</param>
        /// <returns></returns>
        public static bool update(Connection conn, CustomerDTO customer)
        {
            string queryString = "update Customer set name='" + customer.name +
                "',email='" + customer.email +
                "',address='" + customer.address +
                "',point=" + customer.point +
                ",is_banned=" + customer.isBanned +
                " where id=" + customer.ID;
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
