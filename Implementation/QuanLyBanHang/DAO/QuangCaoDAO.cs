using DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DAO
{
    public class QuangCaoDAO
    {
        public QuangCaoDAO()
        {
        }
        public List<QuangCaoDTO> getAllItem(Connection conn)
        {
            List<QuangCaoDTO> result = new List<QuangCaoDTO>();

            string queryString = "select* from quangcao where isDeleted = 0";
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
                        QuangCaoDTO temp = new QuangCaoDTO(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetInt32(3));
                        result.Add(temp);
                    }

                }
            }

            return result;
        }

        public bool AddQuangCao(Connection conn, QuangCaoDTO data)
        {
            //  INSERT INTO `quanlybanhang`.`quangcao` (`TieuDe`, `NoiDung`, `isDeleted`) VALUES('dien thoai sam sung', 'sam sung no1', 0);

            string queryString = "INSERT INTO quangcao (`TieuDe`, `NoiDung`, `isDeleted`) VALUES('"+data.TieuDe+"', '"+data.NoiDung+"', "+data.isDeleted+");";
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
