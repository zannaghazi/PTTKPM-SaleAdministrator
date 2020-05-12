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
    /// Domain layer to manage Khach hang
    /// </summary>
    public class QuanLyKhachHangDomain
    {
        public List<Models.Customer> listKhachHang = new List<Models.Customer>();

        /// <summary>
        /// Constructor
        /// </summary>
        public QuanLyKhachHangDomain()
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="listKhachHang">list Khach hang</param>
        public QuanLyKhachHangDomain(List<Customer> listKhachHang)
        {
            this.listKhachHang = listKhachHang;
        }

        /// <summary>
        /// find name in list customer by id
        /// </summary>
        /// <param name="id">Id to find name of customer</param>
        /// <returns></returns>
        public Models.Customer findCustomerByID(int id)
        {
            foreach (Customer customer in this.listKhachHang)
            {
                if (customer.ID == id)
                    return customer;
            }
            return null;
        }

        /// <summary>
        /// Load data of Khach hang from Database
        /// </summary>
        public void LoadKhachHang(Repository.Repository repository)
        {
            this.listKhachHang = new List<Models.Customer>();

            string queryString = "select * from customer";
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
                        Models.Customer temp = new Models.Customer(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetBoolean(4));
                        this.listKhachHang.Add(temp);
                    }

                }
            }
        }
    }

}
