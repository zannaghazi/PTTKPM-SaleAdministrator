using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.Domains
{
    /// <summary>
    /// Domain layer for feature "QuanLyBinhLuan"
    /// </summary>
    public class QuanLyBinhLuanDomain
    {
        public List<Models.Comment> listBinhLuan = new List<Models.Comment>();

        /// <summary>
        /// Constructor
        /// </summary>
        public QuanLyBinhLuanDomain()
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="listBinhLuan">List binh luan</param>
        public QuanLyBinhLuanDomain(List<Comment> listBinhLuan)
        {
            this.listBinhLuan = listBinhLuan;
        }

        /// <summary>
        /// Load data of Binh Luan from Database
        /// </summary>
        public void LoadBinhLuan(Repository.Repository repository, int role)
        {
            this.listBinhLuan = new List<Models.Comment>();
            string queryString = "select * from comment";
            if (role == Constants.USERTYPE_MANAGER)
            {
                queryString += " where status > 0 order by time_update DESC ";
            }
            else if(role == Constants.USERTYPE_SALE)
            {
                queryString += " where status = 0 order by status ASC ";
            }
            repository.cmd.CommandText = queryString;

            using (DbDataReader reader = repository.cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    MessageBox.Show(
                        "Data chưa có dữ liệu",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    while (reader.Read())
                    {
                        Models.Comment temp = new Models.Comment(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetInt32(2),
                            reader.GetInt32(3),
                            reader.GetString(4),
                            reader.GetDateTime(5).ToString(),
                            reader.GetInt32(6));
                        this.listBinhLuan.Add(temp);
                    }

                }
            }
        }

        /// <summary>
        /// Load comment in a period time
        /// </summary>
        /// <param name="repository">my repository</param>
        /// <param name="startTime">startime</param>
        /// <param name="endTime">endtime</param>
        public List<Comment> LoadBinhLuanInPeriod(Repository.Repository repository, string startTime, string endTime)
        {
            this.listBinhLuan = new List<Models.Comment>();
            string queryString = $"select * from comment where time_update between '{startTime}' and '{endTime}'";
            repository.cmd.CommandText = queryString;

            using (DbDataReader reader = repository.cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    MessageBox.Show(
                        "Data chưa có dữ liệu",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return null;
                }
                else
                {
                    while (reader.Read())
                    {
                        Models.Comment temp = new Models.Comment(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetInt32(2),
                            reader.GetInt32(3),
                            reader.GetString(4),
                            reader.GetDateTime(5).ToString(),
                            reader.GetInt32(6));
                        this.listBinhLuan.Add(temp);
                    }
                    return this.listBinhLuan;

                }
            }
        }

        /// <summary>
        /// Phan loai binh luan
        /// </summary>
        /// <param name="repository">my repository</param>
        /// <param name="cmt">cmt phan loai</param>
        public void UpdateBinhluan(Repository.Repository repository, int status, int id, int role)
        {
            DateTime serverTime = DateTime.Now;
            string queryString = $"update comment set status = {status}," +
                $"time_update = '{serverTime.ToString("yyyy-MM-dd H:mm:ss")}' where id = {id}";
            repository.cmd.CommandText = queryString;
            try
            {
                repository.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Có lỗi xảy ra trong quá trình cập nhật dữ liệu, vui lòng thử lại!\nChi tiết: " + ex.StackTrace,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            this.LoadBinhLuan(repository, role);
        }

        /// <summary>
        /// Đánh dấu bình luận đã xử lý
        /// </summary>
        /// <param name="repository">my repository</param>
        public void handleMark(Repository.Repository repository, int type, int id, int role)
        {
            string queryString = $"update comment set handle_type = {type} where id = {id}";
            repository.cmd.CommandText = queryString;
            try
            {
                repository.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Có lỗi xảy ra trong quá trình cập nhật dữ liệu, vui lòng thử lại!\nChi tiết: " + ex.StackTrace,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            this.LoadBinhLuan(repository, role);
        }
    }
}
