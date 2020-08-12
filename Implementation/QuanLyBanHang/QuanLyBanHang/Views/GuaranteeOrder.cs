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
    public partial class GuaranteeOrder : Form
    {
        private InitPage parent;
        private List<GuaranteeItemDTO> itemData = new List<GuaranteeItemDTO>();
        public GuaranteeOrder()
        {
            InitializeComponent();
            this.InitSetting();
        }

        public GuaranteeOrder(InitPage parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.InitSetting();
        }

        public void InitSetting()
        {
            int listDataSize = this.listData.Width;
            this.listData.Columns[0].Width = listDataSize / 9;
            this.listData.Columns[1].Width = listDataSize * 2 / 9;
            this.listData.Columns[2].Width = listDataSize * 3 / 9;
            this.listData.Columns[3].Width = listDataSize * 4 / 9;

            this.txtProvider.Text = "";
            this.listData.Enabled = false;
            this.btnConfirm.Enabled = false;
            this.btnDecline.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.listData.Items.Clear();
            string provider = this.txtProvider.Text.Trim();

            List<GuaranteeItemDTO> data = this.parent.quanLySanPhamBUS.getListGuaranteeItemByProvider(this.parent.conn, provider);

            if (data.Count == 0)
            {
                MessageBox.Show("Nhà phân phối không hợp lệ hoặc không có sản phẩm đổi trả!",
                    "Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            this.itemData = data;
            for (int i = 0; i < data.Count; i++)
            {
                ListViewItem tempItem = new ListViewItem(data[i].ID.ToString());

                ItemDTO item = this.parent.quanLySanPhamBUS.GetItemByID(this.parent.conn, data[i].itemID);
                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, item.name));
                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, data[i].stats));
                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, data[i].reason));

                this.listData.Items.Add(tempItem);
            }
            this.btnConfirm.Enabled = true;
            this.btnDecline.Enabled = true;
        }

        private void txtProvider_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSearch.PerformClick();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.itemData.Count == 0)
            {
                this.Close();
            }else
            {
                if (MessageBox.Show("Bạn có chắc muốn duyệt tất cả sản phẩm trên?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int i = 0; i < this.itemData.Count; i++)
                    {
                        this.parent.quanLySanPhamBUS.ApproveGuaranteeItem(this.parent.conn, this.itemData[i].ID);
                    }
                    MessageBox.Show("Tạo đơn trả hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.listData.Items.Clear();
                    this.itemData.Clear();
                    this.InitSetting();
                    // Create mail and send to provider is out of scope
                }
            }
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            if (this.itemData.Count == 0)
            {
                this.Close();
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa tất cả sản phẩm trên?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int i = 0; i < this.itemData.Count; i++)
                    {
                        this.parent.quanLySanPhamBUS.DeleteGuaranteeItem(this.parent.conn, this.itemData[i].ID);
                    }
                    MessageBox.Show("Xóa các mặt hàng cần trả thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.listData.Items.Clear();
                    this.itemData.Clear();
                    this.InitSetting();
                }
            }
        }
    }
}
