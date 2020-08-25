using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DAO;
using DTO;
namespace BUS
{
    public class QuanLyQuangCaoBUS
    {
        public QuangCaoDAO QuangCaoDAO;
        public DoiTacDAO DoiTacDAO;
        public QCsdtDAO QCsdtDAO;

        public List<QuangCaoDTO> listQuangCao = new List<QuangCaoDTO>();
        public List<DoiTacDTO> listDoiTac = new List<DoiTacDTO>();
        public List<QCsdtDTO> listQCsdt = new List<QCsdtDTO>();
        public List<QCsdtDTO> listQCsdtLS = new List<QCsdtDTO>();
        public QuanLyQuangCaoBUS()
        {
            QuangCaoDAO = new QuangCaoDAO();
            DoiTacDAO = new DoiTacDAO();
            QCsdtDAO = new QCsdtDAO();
        }

        public void LoadQuangCao(Connection conn)
        {
            this.listQuangCao = new List<QuangCaoDTO>();
            this.listQuangCao = QuangCaoDAO.getAllItem(conn);
        }

        public void LoadDoiTac(Connection conn)
        {
            this.listDoiTac = new List<DoiTacDTO>();
            this.listDoiTac = DoiTacDAO.getAllItem(conn);
        }

        public void LoadQCsdt(Connection conn)
        {
            this.listQCsdt = new List<QCsdtDTO>();
            this.listQCsdt = QCsdtDAO.getAllItem(conn);
        }

        public void LoadQCsdtLS(Connection conn,int day)
        {
            this.listQCsdtLS = new List<QCsdtDTO>();
            this.listQCsdtLS = QCsdtDAO.getItemlastday(conn,day);
        }

        public void AddQuangCao(Connection conn, QuangCaoDTO data)
        {
            bool result = this.QuangCaoDAO.AddQuangCao(conn, data);
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
                this.LoadQuangCao(conn);
                MessageBox.Show("Tạo Quảng Cáo Thành Công !!!!!!");
            }
        }

        public void AddDoiTac(Connection conn, DoiTacDTO data,int IDBaiQC)
        {
            bool result = this.DoiTacDAO.AddDoiTac(conn, data, IDBaiQC);
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
                this.LoadDoiTac(conn);
                MessageBox.Show("Tạo Đối Tác Thành Công !!!!!!");
            }
        }

        public void AddQCSDT(Connection conn, List<QCsdtDTO> data,int IDBaiQC)
        {
            bool result = this.QCsdtDAO.AddQuangCaoSDT(conn, data, IDBaiQC);
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
                this.LoadQCsdt(conn);
                MessageBox.Show("Gửi Quảng Cáo Thành Công !!!!!!");
            }
        }

        public void EDITDoiTac(Connection conn, DoiTacDTO data,int ID)
        {
            bool result = this.DoiTacDAO.EDITDoiTac(conn, data,ID);
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
                this.LoadDoiTac(conn);
                MessageBox.Show("Edit Đối Tác Thành Công !!!!!!");
            }
        }
    }
}
