using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BUS
{
    public class QuanLyThanhToanBUS
    {
        public HoaDonDAO HoaDonDAO;
        public List<HoaDonDTO> listHoaDon = new List<HoaDonDTO>();

        public QuanLyThanhToanBUS()
        {
            HoaDonDAO = new HoaDonDAO();
        }
        public void LoadHoaDon(Connection conn)
        {
            this.listHoaDon = new List<HoaDonDTO>();
            this.listHoaDon = HoaDonDAO.getAllItem(conn);
        }

        public void EDITHoaDon(Connection conn, int data)
        {
            bool result = this.HoaDonDAO.EditHoaDon(conn, data);
            if (!result)
            {
                MessageBox.Show(
                   "Có lỗi xảy ra trong quá trình thêm dữ liệu, vui lòng thử lại!",
                   "Lỗi",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
            else
            {
                this.LoadHoaDon(conn);
                MessageBox.Show(" Thành Công !!!!!!");
            }
        }
    }
}
