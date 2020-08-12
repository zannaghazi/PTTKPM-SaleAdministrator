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
    public partial class GuaranteeSanPham : Form
    {
        private InitPage parent;
        private int currentitem = -1;
        public GuaranteeSanPham()
        {
            InitializeComponent();
        }

        public GuaranteeSanPham(InitPage parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.InitSetting();
        }

        public void InitSetting()
        {
            this.txtItemName.Enabled = false;
            this.txtItemProvider.Enabled = false;
            this.SetEnableFields(false);
        }

        public void SetEnableFields(bool stat)
        {
            this.txtStatus.Enabled = stat;
            this.txtReason.Enabled = stat;
            this.btnConfirm.Enabled = stat;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int id = -1;
            try
            {
                id = Int32.Parse(this.txtItemID.Text);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            ItemDTO item = this.parent.quanLySanPhamBUS.GetItemByID(this.parent.conn, id);
            if (item.name == null)
            {
                MessageBox.Show("Mã không phù hợp với sản phẩm nào!\nVui lòng thử lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
            {
                this.txtItemName.Text = item.name;
                this.txtItemProvider.Text = item.provider;
                this.currentitem = id;
                this.SetEnableFields(true);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string reason = this.txtReason.Text;
            string stats = this.txtStatus.Text;

            if (String.IsNullOrWhiteSpace(reason) || String.IsNullOrWhiteSpace(stats))
            {
                MessageBox.Show(
                    "Dữ liệu nhập vào chưa đủ, vui lòng thử lại!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }else
            {
                GuaranteeItemDTO item = new GuaranteeItemDTO(this.parent.currentUser.ID, this.currentitem, this.txtItemProvider.Text, stats, reason, false);
                if (this.parent.quanLySanPhamBUS.guaranteeItemDAO.AddNewGuaranteeItem(this.parent.conn, item))
                {
                    MessageBox.Show(
                        "Thêm thông tin sản phẩm trả thành công!",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    this.Close();
                }else
                {
                    MessageBox.Show(
                    "Đã có lỗi xảy ra trong quá trình thêm!\nXin vui lòng thử lại",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtItemID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSearch.PerformClick();
            }
        }
    }
}
