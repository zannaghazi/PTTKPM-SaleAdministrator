using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.Views
{
    public partial class CreateDoiTac : Form
    {
        private InitPage parent = new InitPage();
        private int itemIndex = -1;
        private int OpenMode = 0;
        private static readonly int MODE_ADD = 0;
        private static readonly int MODE_EDIT = 1;
        private DoiTacDTO EditDoiTac = new DoiTacDTO();
        private int IDBaiQC = -1;
        public CreateDoiTac(InitPage parent,int IDBaiQC)
        {
            InitializeComponent();
            this.OpenMode = MODE_ADD;
            this.parent = parent;
            this.IDBaiQC = IDBaiQC;
        }

        public CreateDoiTac(int index, DoiTacDTO item,InitPage parent)
        {
            InitializeComponent();
            this.OpenMode = MODE_EDIT;
            this.itemIndex = index;
            this.parent = parent;
            this.EditDoiTac = item;
            this.TenDoiTac.Text = item.Ten;
            this.NgayKyHD.Value = item.NgayKyHD;
            this.NgayKetThucHD.Value = item.NgayHetHanHD;
            this.ViTriDang.Text = item.ViTriDang;
        }

        private void Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoiTacDTO temp = null;
            try
            {

                temp = new DoiTacDTO(
                    this.TenDoiTac.Text.Trim(),
                    this.NgayKyHD.Value.Date,
                    this.NgayKetThucHD.Value.Date,
                    this.ViTriDang.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã có dữ liệu sai định dạng!\nLàm ơn kiểm tra và lưu lại",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
            if (temp != null)
            {
                if (OpenMode == 0)
                {
                    this.parent.quanLyQuangCaoBUS.AddDoiTac(this.parent.conn, temp, this.IDBaiQC);
                }else if (OpenMode == 1)
                {
                    
                    this.parent.quanLyQuangCaoBUS.EDITDoiTac(this.parent.conn, temp, EditDoiTac.ID);
                }
                
                this.parent.dataDoiTac = this.parent.quanLyQuangCaoBUS.listDoiTac;
                this.parent.LoadDoiTacCallback();
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Đã có dữ liệu sai định dạng!\nLàm ơn kiểm tra và lưu lại",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
