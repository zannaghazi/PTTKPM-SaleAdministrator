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
    /// Domain layer for feature "QuanLyBimhLuan"
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
        public void LoadBinhLuan(Repository.Repository repository)
        {
            this.listBinhLuan = new List<Models.Comment>();

            string queryString = "select * from comment";
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
                            reader.GetString(2),
                            reader.GetInt32(3),
                            reader.GetString(4));
                        this.listBinhLuan.Add(temp);
                    }

                }
            }
        }
    }
}
