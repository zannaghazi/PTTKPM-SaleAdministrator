using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace QuanLyBanHang.Views
{
    public partial class CreateSanPhamImportOrder : Form
    {
        public static readonly int MODE_CREATE_IMPORT = 0;
        public static readonly int MODE_CREATE_RETURN = 1;
        public static readonly int MODE_APPROVE = 2;

        private InitPage parent = new InitPage();
        private List<ItemDTO> data = new List<ItemDTO>();
        private int selectedIndex;
        private int mode = 0;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CreateSanPhamImportOrder()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Constructor with fill data to fields
        /// </summary>
        /// <param name="parent"></param>
        public CreateSanPhamImportOrder(InitPage parent, int mode, int itemOrder)
        {
            this.InitializeComponent();
            this.parent = parent;
            this.selectedIndex = itemOrder;
            this.mode = mode;
            this.data = parent.quanLySanPhamDomain.GetLowAmountItem(parent.repository);
            this.InitFormSetting();
            this.LoadData();
        }

        public CreateSanPhamImportOrder(InitPage parent, int mode, ItemOrderDTO order, int itemOrder)
        {
            this.InitializeComponent();
            this.parent = parent;
            this.selectedIndex = itemOrder;
            this.mode = mode;
            this.InitFormSetting();
            this.LoadOrderData(order);
        }

        /// <summary>
        /// Form setting
        /// </summary>
        private void InitFormSetting()
        {
            int listSize = this.listSP.Width;
            this.listSP.Columns[0].Width = listSize / 11;
            this.listSP.Columns[1].Width = listSize * 3 / 11;
            this.listSP.Columns[2].Width = listSize * 2/ 11;
            this.listSP.Columns[3].Width = listSize * 2/ 11;
            this.listSP.Columns[4].Width = listSize * 3/ 11;

            if (this.mode == MODE_CREATE_IMPORT)
            {
                this.btnOK.Text = "Tạo đơn nhập hàng";
                this.lbTitle.Text = "Tạo đơn nhập hàng";
                this.txtDate.Text = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
                this.txtOwner.Text = this.parent.currentUser.name;
            }
            else if (this.mode == MODE_CREATE_RETURN)
            {
                this.btnOK.Text = "Tạo đơn trả hàng";
                this.lbTitle.Text = "Tạo đơn trả hàng";
                this.txtDate.Text = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
                this.txtOwner.Text = this.parent.currentUser.name;
            }
            else
            {
                this.btnOK.Visible = false;
                this.lbTitle.Text = "Phê duyệt đơn hàng";
                this.listSP.Enabled = false;
                this.btnSelectAll.Text = "Phê duyệt";
                this.btnDeselectAll.Text = "Từ chối";
            }
        }

        /// <summary>
        /// Load data to Listview
        /// </summary>
        private void LoadData()
        {
            if (this.data.Count == 0 || this.data == null)
            {
                if (this.mode == MODE_CREATE_IMPORT)
                {
                    MessageBox.Show(
                        "Không có sản phẩm nào có số lượng thấp hơn quy định!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }else if (this.mode == MODE_CREATE_RETURN)
                {
                    MessageBox.Show(
                        "Không có sản phẩm đổi trả nào!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else if (this.mode == MODE_APPROVE)
                {
                    MessageBox.Show(
                        "Không có sản phẩm nào, Đơn lỗi!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                this.btnOK.Enabled = false;
                this.btnSelectAll.Enabled = false;
                this.btnDeselectAll.Enabled = false;
            }else
            {
                for (int i = 0; i < this.data.Count; i++)
                {
                    ListViewItem temp = new ListViewItem(this.data[i].ID.ToString());
                    temp.SubItems.Add(new ListViewItem.ListViewSubItem(temp, this.data[i].name));
                    temp.SubItems.Add(new ListViewItem.ListViewSubItem(temp, this.data[i].amount.ToString()));
                    temp.SubItems.Add(new ListViewItem.ListViewSubItem(temp, this.data[i].minimum.ToString()));
                    temp.SubItems.Add(new ListViewItem.ListViewSubItem(temp, this.data[i].provider));

                    this.listSP.Items.Add(temp);
                }
            }

            if (this.mode == MODE_APPROVE)
            {
                for (int i = 0; i < this.listSP.Items.Count; i++)
                {
                    this.listSP.Items[i].Checked = true;
                }
            }
        }

        /// <summary>
        /// Load current order data
        /// </summary>
        /// <param name="order"></param>
        private void LoadOrderData(ItemOrderDTO order)
        {
            this.data = order.listSP;
            this.txtDate.Text = String.Format("{0:MM/dd/yyyy}", order.date);
            this.txtOwner.Text = order.owner;
            this.LoadData();
        }

        /// <summary>
        /// Handle event click Cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handle event click Select All button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            if (this.mode == MODE_APPROVE)
            {
                if (MessageBox.Show(
                    "Bạn có chắc chắn muốn phê duyệt đơn nhập hàng này?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ItemOrderDTO temp = this.parent.quanLySanPhamDomain.listSPOrder[this.selectedIndex];
                    temp.isApproved = true;
                    this.parent.quanLySanPhamDomain.UpdateItemOrder(
                        this.parent.repository,
                        temp,
                        this.parent);
                }
            } else {
                for (int i = 0; i < this.listSP.Items.Count; i++)
                {
                    this.listSP.Items[i].Checked = true;
                }
            }
        }

        /// <summary>
        /// Handle event click Deselect All button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeselectAll_Click(object sender, EventArgs e)
        {
            if (this.mode == MODE_APPROVE)
            {
                if (MessageBox.Show(
                    "Bạn có chắc chắn muốn từ chối đơn nhập hàng này?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.parent.quanLySanPhamDomain.DeleteItemOrder(
                        this.parent.repository,
                        this.parent.quanLySanPhamDomain.listSPOrder[this.selectedIndex],
                        this.parent);
                    this.Close();
                }
            }
            else {
                for (int i = 0; i < this.listSP.Items.Count; i++)
                {
                    this.listSP.Items[i].Checked = false;
                }
            }
        }

        /// <summary>
        /// Handle event click Confirm button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (this.mode == MODE_CREATE_IMPORT)
            {
                if (MessageBox.Show(
                    "Bạn có chắc muốn lập đơn nhập hàng này?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Get all selected Item
                    List<ItemDTO> selectedItem = new List<ItemDTO>();
                    for (int i = 0; i < this.listSP.Items.Count; i++)
                    {
                        if (this.listSP.Items[i].Checked)
                        {
                            selectedItem.Add(this.data[i]);
                        }
                    }

                    ItemOrderDTO temp = new ItemOrderDTO(
                        DateTime.Now,
                        this.parent.currentUser.name,
                        Models.ItemOrder.IMPORT,
                        selectedItem,
                        false);
                    this.parent.quanLySanPhamDomain.AddSanPhamImportOrder(this.parent.repository, temp, this.parent);
                }
                this.Close();
            }
            else if (this.mode == MODE_CREATE_RETURN)
            {

            }
            else if (this.mode == MODE_APPROVE)
            {
                
            }
        }
    }
}
