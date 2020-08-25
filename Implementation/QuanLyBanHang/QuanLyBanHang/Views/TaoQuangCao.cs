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
    public partial class TaoQuangCao : Form
    {
        private InitPage parent = new InitPage();
        public TaoQuangCao(InitPage parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuangCaoDTO temp = null;
            try
            {
                temp = new QuangCaoDTO(
                    this.TieuDe.Text.Trim(),
                    this.NoiDung.Text.Trim());
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
                this.parent.quanLyQuangCaoBUS.AddQuangCao(this.parent.conn, temp);
                this.parent.dataQuangCao = this.parent.quanLyQuangCaoBUS.listQuangCao;
                this.parent.LoadQuangCaoCallback();
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
