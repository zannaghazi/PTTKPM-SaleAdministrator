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
    public partial class SanPhamDetail : Form
    {
        private InitPage parent = new InitPage();
        private int itemIndex = -1;
        private int OpenMode = 0;

        private static readonly int MODE_ADD = 0;
        private static readonly int MODE_EDIT = 1;
        /// <summary>
        /// Default constructor
        /// </summary>
        public SanPhamDetail(InitPage parent)
        {
            this.InitializeComponent();
            this.txtID.Enabled = false;
            this.OpenMode = MODE_ADD;
            this.parent = parent;
        }

        /// <summary>
        /// Monitor SanPham information to fields and show UI as privilege
        /// </summary>
        /// <param name="item"></param>
        public SanPhamDetail(int index, Models.Item item, Models.User user, InitPage parent)
        {
            this.parent = parent;
            this.itemIndex = index;
            this.OpenMode = MODE_EDIT;

            this.InitializeComponent();
            this.lbName.Text = item.name;
            this.txtID.Text = item.ID.ToString();
            this.txtName.Text = item.name;
            this.txtType.Text = item.type;
            this.txtAmount.Text = item.amount.ToString();
            this.txtMinimum.Text = item.minimum.ToString();

            if (user.role == Constants.USERTYPE_MANAGER)
            {
                this.btnConfirm.Visible = true;
                this.txtAmount.Enabled = true;
                this.txtID.Enabled = false;
                this.txtMinimum.Enabled = true;
                this.txtName.Enabled = true;
                this.txtType.Enabled = true;
            }
            else
            {
                this.btnConfirm.Visible = false;
                this.txtAmount.Enabled = false;
                this.txtID.Enabled = false;
                this.txtMinimum.Enabled = false;
                this.txtName.Enabled = false;
                this.txtType.Enabled = false;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            Models.Item temp = null;
            try
            {
                int id = -1;
                if (!String.IsNullOrWhiteSpace(this.txtID.Text))
                {
                    id = Int32.Parse(this.txtID.Text.Trim());
                }
                temp = new Models.Item(
                    id,
                    this.txtName.Text.Trim(),
                    this.txtType.Text.Trim(),
                    Int32.Parse(this.txtAmount.Text.Trim()),
                    Int32.Parse(this.txtMinimum.Text.Trim()));
            }catch (Exception ex)
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
                if (this.OpenMode == MODE_EDIT)
                {
                    this.parent.quanLySanPhamDomain.UpdateSanPham(this.itemIndex, temp);
                    this.parent.dataSanPham = this.parent.quanLySanPhamDomain.listSanPham;
                    this.parent.LoadSanPhamCallback();
                }else
                {
                    this.parent.quanLySanPhamDomain.AddSanPham(temp);
                    this.parent.dataSanPham = this.parent.quanLySanPhamDomain.listSanPham;
                    this.parent.LoadSanPhamCallback();
                }
                this.Close();
            }else
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
