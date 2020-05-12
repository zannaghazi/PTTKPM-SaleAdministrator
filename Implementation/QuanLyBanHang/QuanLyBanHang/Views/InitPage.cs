using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class InitPage : Form
    {
        /* VARIABLES */
        private int LoginStatus = Constants.LOGINSTAT_NONE; // Login status
        public Models.User currentUser = null; // Logged user
        // TabPage
        private TabPage tabPageSanPham = null;
        private TabPage tabPageComment = null;
        private TabPage tabPageQuangCao = null;
        private TabPage tabPageDatHang = null;
        private TabPage tabPageThanhToan = null;
        // Storage core data
        public List<Models.Item> dataSanPham = new List<Models.Item>();
        public List<Models.Comment> dataBinhLuan = new List<Models.Comment>();
        public List<Models.Customer> dataKhachHang = new List<Models.Customer>();
        // Temporary variable
        private int selectedIndex = -1;
        private int selectedBillIndex = -1;
        private int selectedCommentIndex = -1;
        // Initial Domains
        public Domains.QuanLySanPhamDomain quanLySanPhamDomain = new Domains.QuanLySanPhamDomain();
        public Domains.QuanLyBinhLuanDomain quanLyBinhLuanDomain = new Domains.QuanLyBinhLuanDomain();
        public Domains.QuanLyKhachHangDomain quanLyKhachHangDomain = new Domains.QuanLyKhachHangDomain();
        // Repository
        public Repository.Repository repository = new Repository.Repository();



        /// <summary>
        /// Initial InitPage
        /// </summary>
        public InitPage()
        {
            this.InitializeComponent();
            this.repository.InitDBConnection();
            this.InitFormSetting();
        }

        /// <summary>
        /// Setting for initial form
        /// </summary>
        public void InitFormSetting()
        {
            // Fix columnsize for table of SanPham
            int listSPSize = this.listSanPham.Width;
            this.listSanPham.Columns[0].Width = listSPSize / 11;
            this.listSanPham.Columns[1].Width = listSPSize * 3 / 11;
            this.listSanPham.Columns[2].Width = listSPSize * 3 / 11;
            this.listSanPham.Columns[3].Width = listSPSize * 2 / 11;
            this.listSanPham.Columns[4].Width = listSPSize * 2 / 11;
            listSPSize = this.listSPBill.Width;
            this.listSPBill.Columns[0].Width = listSPSize / 3;
            this.listSPBill.Columns[1].Width = listSPSize * 2 / 3;

            //Fix column size for table of Comment
            int listCMTSize = this.listComment.Width;
            this.listComment.Columns[0].Width = listCMTSize / 11;
            this.listComment.Columns[1].Width = listCMTSize * 3 / 11;
            this.listComment.Columns[2].Width = listCMTSize * 3 / 11;
            this.listComment.Columns[3].Width = listCMTSize * 2 / 11;
            this.listComment.Columns[4].Width = listCMTSize * 2 / 11;
            listCMTSize = this.listCommentRep.Width;
            this.listCommentRep.Columns[0].Width = listCMTSize / 3;
            this.listCommentRep.Columns[1].Width = listCMTSize * 2 / 3;

            // Backup tabPage data
            this.tabPageSanPham = this.tabSanPham;
            this.tabPageComment = this.tabComment;
            this.tabPageQuangCao = this.tabQuangCao;
            this.tabPageDatHang = this.tabDatHang;
            this.tabPageThanhToan = this.tabThanhToan;

            // Remove all tabpage from tabControl
            this.tabControl.TabPages.Remove(this.tabSanPham);
            this.tabControl.TabPages.Remove(this.tabComment);
            this.tabControl.TabPages.Remove(this.tabQuangCao);
            this.tabControl.TabPages.Remove(this.tabDatHang);
            this.tabControl.TabPages.Remove(this.tabThanhToan);
    }


        /* SUPPORT FUNCTION */
        /// <summary>
        /// Function call back for login
        /// </summary>
        /// <param name="temp">user's information</param>
        public void LoginCallback(Models.User temp)
        {
            // Login information
            this.btnLogin.Text = "Logout: " + temp.name;
            this.LoginStatus = Constants.LOGINSTAT_LOGGED;
            this.currentUser = temp;

            // User Role change UI
            if (temp.role == Constants.USERTYPE_MANAGER)
            {
                /* QUAN LY SAN PHAM */
                // Load available TabPage
                this.tabControl.TabPages.Insert(0, this.tabPageSanPham);
                // Change UI
                this.listSPBill.Enabled = true;
                this.btnSPAdd.Enabled = true;
                this.btnSPDelete.Enabled = true;
                // Load data
                this.quanLySanPhamDomain.LoadSanPham(this.repository);
                this.quanLySanPhamDomain.LoadSanPhamOrder(this.repository);
                this.quanLyBinhLuanDomain.LoadBinhLuan(this.repository);
                this.quanLyKhachHangDomain.LoadKhachHang(this.repository);
                this.dataSanPham = this.quanLySanPhamDomain.listSanPham;
                this.dataBinhLuan = this.quanLyBinhLuanDomain.listBinhLuan;
                this.dataKhachHang = this.quanLyKhachHangDomain.listKhachHang;
                this.LoadSanPhamCallback();
                this.LoadSPOrderCallback();
                this.LoadBinhLuanCallback();

                /* QUAN LY COMMENT */
                this.tabControl.TabPages.Insert(1, this.tabPageComment);
                this.listCommentRep.Enabled = true;

            }else if (temp.role == Constants.USERTYPE_SALE)
            {
                /* QUAN LY SAN PHAM */
                // Load available TabPage
                this.tabControl.TabPages.Insert(0, this.tabPageSanPham);
                // Change UI
                this.listSPBill.Enabled = false;
                this.btnSPAdd.Enabled = false;
                this.btnSPDelete.Enabled = false;
                //Load data
                this.quanLySanPhamDomain.LoadSanPham(this.repository);
                this.quanLySanPhamDomain.LoadSanPhamOrder(this.repository);
                this.quanLyBinhLuanDomain.LoadBinhLuan(this.repository);
                this.quanLyKhachHangDomain.LoadKhachHang(this.repository);
                this.dataSanPham = this.quanLySanPhamDomain.listSanPham;
                this.dataBinhLuan = this.quanLyBinhLuanDomain.listBinhLuan;
                this.dataKhachHang = this.quanLyKhachHangDomain.listKhachHang;
                this.LoadSanPhamCallback();
                this.LoadSPOrderCallback();
                this.LoadBinhLuanCallback();
            }
            else if (temp.role == Constants.USERTYPE_ADVERTISER)
            {

            }else if (temp.role == Constants.USERTYPE_SHIPPER)
            {

            }else if (temp.role == Constants.USERTYPE_TREASURER)
            {

            }else
            {
                MessageBox.Show("Tài khoản của bạn chưa được phân quyền.\nLiên hệ với quản lý để tìm hiểu thêm",
                    "Lỗi phân quyền",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.LogoutCallback();
            }
        }

        /// <summary>
        /// Function call back for logout
        /// </summary>
        /// <param name="temp">user's information</param>
        public void LogoutCallback()
        {
            // Logout information
            this.btnLogin.Text = "Login";
            this.LoginStatus = Constants.LOGINSTAT_NONE;
            this.currentUser = null;

            // Clear tab
            this.InitFormSetting();

            // Remove all session data
            this.selectedIndex = -1;

            /* QUAN LY SAN PHAM */
            this.dataSanPham = new List<Models.Item>();
            this.listSanPham.Items.Clear();
        }

        public void LoadSanPhamCallback()
        {
            // Remove all current data
            this.listSanPham.Items.Clear();

            // Add data to list
            for (int i = 0; i < this.dataSanPham.Count; i++)
            {
                ListViewItem tempItem = new ListViewItem(this.dataSanPham[i].ID.ToString());

                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, this.dataSanPham[i].name));
                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, this.dataSanPham[i].type));
                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, this.dataSanPham[i].amount.ToString()));
                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, this.dataSanPham[i].minimum.ToString()));
                
                if (this.dataSanPham[i].amount < this.dataSanPham[i].minimum)
                {
                    tempItem.BackColor = Color.Red;
                }

                this.listSanPham.Items.Add(tempItem);
            }
        }

        public void LoadBinhLuanCallback()
        {
            // Remove all current data
            this.listComment.Items.Clear();

            // Add data to list
            for (int i = 0; i < this.dataBinhLuan.Count; i++)
            {
                ListViewItem tempItem = new ListViewItem(this.dataBinhLuan[i].ID.ToString());
                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, this.quanLySanPhamDomain.findProductByID(this.dataBinhLuan[i].productID).name));
                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, this.quanLyKhachHangDomain.findCustomerByID(this.dataBinhLuan[i].customerID).name));
                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, MyEnum.EnumHelper.StringValueOf((MyEnum.MyEnum.TypeComment)this.dataBinhLuan[i].status)));
                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, this.dataBinhLuan[i].detail));

                this.listComment.Items.Add(tempItem);
            }
        }

        public void LoadSPOrderCallback()
        {
            // Remove all current data
            this.listSPBill.Items.Clear();

            if (this.quanLySanPhamDomain.listSPOrder.Count > 0)
            {
                for (int i = 0; i < this.quanLySanPhamDomain.listSPOrder.Count; i++)
                {
                    ListViewItem tempItem = new ListViewItem(String.Format("{0:MM/dd/yyyy}", this.quanLySanPhamDomain.listSPOrder[i].date));
                    tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, this.quanLySanPhamDomain.listSPOrder[i].owner));
                    this.listSPBill.Items.Add(tempItem);
                }
            }
        }

        /// <summary>
        /// Handle event click Exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Bạn có chắc muốn thoát khỏi ứng dụng?",
                "Thoát ứng dụng",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Handle event click Minimize button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Handle event click Login button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Views.LoginForm loginForm = new Views.LoginForm(this);
            if (this.LoginStatus == Constants.LOGINSTAT_NONE)
            {
                loginForm.StartPosition = FormStartPosition.CenterParent;
                loginForm.ShowDialog();
            }else
            {
                if (MessageBox.Show(
                    "Bạn có chắc muốn đăng xuất?",
                    "Đăng xuất",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.LogoutCallback();
                }
            }
        }

        /// <summary>
        /// Not allow user change size of listview column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListSanPham_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = this.listSanPham.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        /// <summary>
        /// Handle event select a report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListCommentRep_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = this.listCommentRep.FocusedItem.Index;
            // Monitor to list data and get Report ID
            Views.CommentReportDetail dialog = new Views.CommentReportDetail
            {
                StartPosition = FormStartPosition.CenterParent
            };
            dialog.ShowDialog();
        }

        /// <summary>
        /// Handle event select SanPham from list Sanpham
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.listSanPham.FocusedItem.Index;
            if (index == this.selectedIndex)
            {
                return;
            }
            this.selectedIndex = index;
            Views.SanPhamDetail detailForm = new Views.SanPhamDetail(index, this.dataSanPham[index], this.currentUser, this)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            detailForm.ShowDialog();
        }

        private void BtnSPCreateBill_Click(object sender, EventArgs e)
        {
            Views.CreateSanPhamImportOrder createSanPhamImportOrder = new Views.CreateSanPhamImportOrder(this, Views.CreateSanPhamImportOrder.MODE_CREATE_IMPORT)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            createSanPhamImportOrder.ShowDialog();
        }

        private void BtnSPAdd_Click(object sender, EventArgs e)
        {
            Views.SanPhamDetail detailForm = new Views.SanPhamDetail(this)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            detailForm.ShowDialog();
        }

        private void BtnSPDelete_Click(object sender, EventArgs e)
        {
            if (this.selectedIndex < 0)
            {
                MessageBox.Show(
                        "Bạn chưa chọn sản phẩm nào cả",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show(
                "Bạn có chắc muốn xoá sản phẩm này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.quanLySanPhamDomain.DeleteSanPham(this.dataSanPham[this.selectedIndex]);
                this.dataSanPham = this.quanLySanPhamDomain.listSanPham;
                this.LoadSanPhamCallback();
            }
            else
            {
                return;
            }
        }

        private void ListSPBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.listSPBill.FocusedItem.Index;
            if (index == this.selectedIndex)
            {
                return;
            }
            this.selectedBillIndex = index;

            Views.CreateSanPhamImportOrder orderForm = new Views.CreateSanPhamImportOrder(this, Views.CreateSanPhamImportOrder.MODE_APPROVE, this.quanLySanPhamDomain.listSPOrder[index])
            {
                StartPosition = FormStartPosition.CenterParent
            };
            orderForm.ShowDialog();
        }

        private void ListSPBill_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = this.listSPBill.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        private void listComment_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.listComment.FocusedItem.Index;
            if (index == this.selectedCommentIndex)
            {
                return;
            }
            this.selectedCommentIndex = index;

            Models.Customer customer = this.quanLyKhachHangDomain.findCustomerByID(this.dataBinhLuan[index].customerID);
            Models.Item product = this.quanLySanPhamDomain.findProductByID(this.dataBinhLuan[index].productID);
            Views.CommentDetail commentDetailForm = new Views.CommentDetail(index, this.dataBinhLuan[index], this.currentUser, customer, product, this)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            commentDetailForm.ShowDialog();
        }
    }
}
