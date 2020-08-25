using DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DAO
{
    public class QCsdtDAO
    {
        public QCsdtDAO()
        {
        }

        public List<QCsdtDTO> getAllItem(Connection conn)
        {
            List<QCsdtDTO> result = new List<QCsdtDTO>();

            string queryString = "select cs.name,cs.sdt,qc.dateqc,qc.IdBaiQC from (SELECT * FROM customer where sdt != 0) as cs  left join (SELECT * FROM quanlybanhang.quangcaosdt where dateqc >= DATE_ADD(now(), INTERVAL -7 DAY)) as qc on cs.sdt=qc.sdt;";
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
                        
                        if (reader.IsDBNull(2))
                        {
                            QCsdtDTO temp = new QCsdtDTO(
                            reader.GetString(0),
                            reader.GetString(1));
                            result.Add(temp);
                        }
                        else
                        {
                            QCsdtDTO temp = new QCsdtDTO(
                            reader.GetString(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetInt16(3));
                            result.Add(temp);
                        }
                    }

                }
            }

            return result;
        }

        public List<QCsdtDTO> getItemlastday(Connection conn,int day)
        {
            List<QCsdtDTO> result = new List<QCsdtDTO>();

            string queryString = "select cs.name,cs.sdt,qc.dateqc,qc.IDBaiQC from (SELECT * FROM customer where sdt != 0) as cs  left join (SELECT * FROM quanlybanhang.quangcaosdt where dateqc >= DATE_ADD(now(), INTERVAL -"+day+" DAY)) as qc on cs.sdt=qc.sdt;";
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

                        if (reader.IsDBNull(2))
                        {
                            QCsdtDTO temp = new QCsdtDTO(
                            reader.GetString(0),
                            reader.GetString(1));
                            result.Add(temp);
                        }
                        else
                        {
                            QCsdtDTO temp = new QCsdtDTO(
                            reader.GetString(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetInt16(3));
                            result.Add(temp);
                        }
                    }

                }
            }

            return result;
        }
        public bool AddQuangCaoSDT(Connection conn, List<QCsdtDTO> data,int IDBaiQC)
        {
            //  INSERT INTO `quanlybanhang`.`quangcaosdt` (`id`, `sdt`, `IDBaiQC`, `dateqc`) VALUES ('2', '0524579215', '2', '2020-05-24 15:48:09');
            for(int i = 0; i < data.Count; i++)
            {
                string queryString = "INSERT INTO quangcaosdt (`sdt`, `IDBaiQC`, `dateqc`) VALUES('" + data[i].sdt + "', '" + IDBaiQC + "', '" + String.Format("{0:yyyy/MM/dd HH:mm:ss}", DateTime.Now) + "');";
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
            }
            return true;
        }

    }
}
