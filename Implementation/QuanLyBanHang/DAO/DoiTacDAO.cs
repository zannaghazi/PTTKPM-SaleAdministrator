using DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DAO
{
    public class DoiTacDAO
    {
        public DoiTacDAO() { }

        public List<DoiTacDTO> getAllItem(Connection conn)
        {
            List<DoiTacDTO> result = new List<DoiTacDTO>();

            string queryString = "select* from qcpartner";
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
                        DoiTacDTO temp = new DoiTacDTO(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetDateTime(2),
                            reader.GetDateTime(3),
                             reader.GetString(4),
                              reader.GetInt32(5));
                        result.Add(temp);
                    }

                }
            }

            return result;
        }

        public bool AddDoiTac(Connection conn, DoiTacDTO data,int IDBaiQC)
        {

            string queryString = "INSERT INTO qcpartner (`partner_name`, `date`, `deadline`,`location`,`IDBaiQC`) VALUES('" + data.Ten + "', '" + String.Format("{0:yyyy/MM/dd HH:mm:ss}", data.NgayKyHD) + "', '"+ String.Format("{0:yyyy/MM/dd HH:mm:ss}", data.NgayHetHanHD) + "','"+data.ViTriDang+"',"+IDBaiQC + ");";
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

        public bool EDITDoiTac(Connection conn, DoiTacDTO data, int ID)
        {
            //UPDATE `quanlybanhang`.`qcpartner` SET `partner_name` = 'qweqwe', `date` = '2020-08-10 00:00:00', `deadline` = '2020-08-29 00:00:00', `location` = 'rea' WHERE(`id` = '5');
            string queryString = "UPDATE qcpartner SET `partner_name` = '"+data.Ten+"', `date` = '"+ String.Format("{0:yyyy/MM/dd HH:mm:ss}", data.NgayKyHD) + "', `deadline` = '"+ String.Format("{0:yyyy/MM/dd HH:mm:ss}", data.NgayHetHanHD) + "', `location` = '"+ data.ViTriDang + "' WHERE(`id` = '"+ID+"');";
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
