using DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DAO
{
    public class HoaDonDAO
    {
        public HoaDonDAO()
        {
        }
        public List<HoaDonDTO> getAllItem(Connection conn)
        {
            List<HoaDonDTO> result = new List<HoaDonDTO>();

            string queryString = "select* from hoadon";
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
                        HoaDonDTO temp = new HoaDonDTO(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                             reader.GetDateTime(3),
                             reader.GetString(4),
                            reader.GetInt32(5));
                        result.Add(temp);
                    }

                }
            }

            return result;
        }

        public bool EditHoaDon(Connection conn, int data)
        {
            string queryString = "UPDATE hoadon SET `TrangThai` = '1' WHERE (`ID` = '"+data+"');";
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
    }
}
