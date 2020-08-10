using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using DTO;

namespace DAO
{
    public class CommentDAO
    {
        public CommentDAO()
        {

        }
        public static List<CommentDTO> getAllComment(Connection conn, int typeSort)
        {
            List<CommentDTO> result = new List<CommentDTO>();

            string queryString = "select * from Comment";
            if (typeSort == 1)
            {
                queryString += " where status > 0 order by time_update DESC ";
            }
            else if (typeSort == 2)
            {
                queryString += " where status = 0 order by status ASC ";
            }
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
                        CommentDTO temp = new CommentDTO(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetInt32(2),
                            reader.GetInt32(3),
                            reader.GetString(4),
                            reader.GetDateTime(5).ToString(),
                            reader.GetInt32(6));
                        result.Add(temp);
                    }

                }
            }

            return result;
        }

        /// <summary>
        /// Load comment in a period time
        /// </summary>
        /// <param name="repository">my repository</param>
        /// <param name="startTime">startime</param>
        /// <param name="endTime">endtime</param>
        public static List<CommentDTO> getCommentByTime(Connection conn, string startTime, string endTime)
        {
            List<CommentDTO> result = new List<CommentDTO>();

            string queryString = $"select * from comment where time_update between '{startTime}' and '{endTime}'";
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
                        CommentDTO temp = new CommentDTO(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetInt32(2),
                            reader.GetInt32(3),
                            reader.GetString(4),
                            reader.GetDateTime(5).ToString(),
                            reader.GetInt32(6));
                        result.Add(temp);
                    }

                }
            }

            return result;
        }

        /// <summary>
        /// update Comment
        /// </summary>
        /// <param name="conn">Connection</param>
        /// <param name="comment">Comment update</param>
        /// <returns></returns>
        public static bool update(Connection conn, CommentDTO comment)
        {
            string queryString = "update Comment set product_id='" + comment.productID +
                "',customer_id='" + comment.customerID +
                "',status=" + comment.status +
                ",detail='" + comment.detail +
                "',time_update='" + comment.timeUpdate +
                "',handle_type=" + comment.handle_type +
                " where id=" + comment.ID;
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

        /// <summary>
        /// Single customer by id
        /// </summary>
        /// <param name="conn">Connection</param>
        /// <param name="id">id customer</param>
        /// <returns></returns>
        public static CommentDTO singleByID(Connection conn, int id)
        {
            string queryString = "select* from Comment where id=" + id;
            conn.cmd.CommandText = queryString;

            using (DbDataReader reader = conn.cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    return new CommentDTO();
                }
                else
                {
                    CommentDTO temp = new CommentDTO();
                    while (reader.Read())
                    {
                        temp = new CommentDTO(
                             reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetInt32(2),
                            reader.GetInt32(3),
                            reader.GetString(4),
                            reader.GetDateTime(5).ToString(),
                            reader.GetInt32(6));
                        break;
                    }
                    return temp;
                }
            }
        }

        /// <summary>
        /// update Comment
        /// </summary>
        /// <param name="conn">Connection</param>
        /// <param name="comment">Comment update</param>
        /// <returns></returns>
        public static bool delete(Connection conn, CommentDTO comment)
        {
            string queryString = "update Comment set is_deleted = " + true +
                " where id=" + comment.ID;
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
