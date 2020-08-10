using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Windows.Forms;
using DAO;
using DTO;

namespace BUS
{
    public class QuanLyKhachHangBUS
    {
        public List<CustomerDTO> listKhachHang = new List<CustomerDTO>();

        /// <summary>
        /// Constructor
        /// </summary>
        public QuanLyKhachHangBUS()
        {

        }

        /// <summary>
        /// Load data of SanPham from Database
        /// </summary>
        public void LoadKhachHang(Connection conn)
        {
            this.listKhachHang = new List<CustomerDTO>();
            this.listKhachHang = CustomerDAO.getAllCustomer(conn);
        }

        /// <summary>
        /// Load khach hang by id
        /// </summary>
        /// <param name="conn">Connection</param>
        /// <param name="id">id khach hang</param>
        /// <returns></returns>
        public CustomerDTO loadKhachHangByID(Connection conn, int id)
        {
            return CustomerDAO.singleByID(conn, id);
        }

        /// <summary>
        /// Tang diem cho khach hang
        /// </summary>
        /// <param name="conn">Connection</param>
        /// <param name="customer_id">id khach hang</param>
        public void tangDiem(Connection conn, int customer_id)
        {
            CustomerDTO temp = this.loadKhachHangByID(conn, customer_id);
            int point = temp.point;
            point++;
            temp.point = point;

            if (CustomerDAO.update(conn, temp))
            {

            }
            else
            {
                MessageBox.Show(
                    "Có lỗi xảy ra trong quá trình cập nhật dữ liệu, vui lòng thử lại!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }        
        }

        /// <summary>
        /// Tang diem cho khach hang
        /// </summary>
        /// <param name="conn">Connection</param>
        /// <param name="customer_id">id khach hang</param>
        public void banNguoiDung(Connection conn, int customer_id)
        {
            CustomerDTO temp = this.loadKhachHangByID(conn, customer_id);
            temp.isBanned = true;

            if (CustomerDAO.update(conn, temp))
            {

            }
            else
            {
                MessageBox.Show(
                    "Có lỗi xảy ra trong quá trình cập nhật dữ liệu, vui lòng thử lại!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
