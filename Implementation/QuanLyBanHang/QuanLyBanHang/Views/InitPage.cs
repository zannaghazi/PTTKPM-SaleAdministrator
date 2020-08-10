using BUS;
using DAO;
using DTO;
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
        private int LoginStatus = DTO.Helper.Constants.LOGINSTAT_NONE; // Login status
        public UserDTO currentUser = null; // Logged user
        // TabPage
        private TabPage tabPageSanPham = null;
        private TabPage tabPageComment = null;
        private TabPage tabPageQuangCao = null;
        private TabPage tabPageDatHang = null;
        private TabPage tabPageThanhToan = null;
        // Storage core data
        public List<ItemDTO> dataSanPham = new List<ItemDTO>();
        public List<CommentDTO> dataBinhLuan = new List<CommentDTO>();
        public List<CustomerDTO> dataKhachHang = new List<CustomerDTO>();
        // Temporary variable
        private int selectedIndex = -1;
        public int selectedBillIndex = -1;
        private int selectedCommentIndex = -1;
        // Initial Domains
        public Domains.QuanLySanPhamDomain quanLySanPhamDomain = new Domains.QuanLySanPhamDomain();

        // Repository
        public Repository.Repository repository = new Repository.Repository();

        //BUS
        public LoginBUS loginBUS = new LoginBUS();
        public QuanLySanPhamBUS quanLySanPhamBUS = new QuanLySanPhamBUS();
        public QuanLyCommentBus quanLyCommentBus = new QuanLyCommentBus();
        public QuanLyKhachHangBUS quanLyKhachHangBus = new QuanLyKhachHangBUS();

        //Connection
        public Connection conn;



        /// <summary>
        /// Initial InitPage
        /// </summary>
        public InitPage()
        {
            this.InitializeComponent();
            this.repository.InitDBConnection();
            this.InitFormSetting();
            this.InitVariable();
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

        public void InitVariable()
        {
            try
            {
                this.conn = new Connection();
            }catch(Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi kết nối với cơ sở dữ liệu!\nVui lòng kiểm tra lại file config!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Console.WriteLine(ex.StackTrace);
            }
        }


        /* SUPPORT FUNCTION */
        /// <summary>
        /// Function call back for login
        /// </summary>
        /// <param name="temp">user's information</param>
        public void LoginCallback(UserDTO temp)
        {
            // Login information
            this.btnLogin.Text = "Logout: " + temp.name;
            this.LoginStatus = DTO.Helper.Constants.LOGINSTAT_LOGGED;
            this.currentUser = temp;

            // User Role change UI
            if (temp.role == DTO.Helper.Constants.USERTYPE_MANAGER)
            {
                /* QUAN LY SAN PHAM */
                // Load available TabPage
                this.tabControl.TabPages.Insert(0, this.tabPageSanPham);
                // Change UI
                this.listSPBill.Enabled = true;
                this.btnSPAdd.Enabled = true;
                this.btnSPImport.Enabled = true;
                // Load data
                this.quanLySanPhamBUS.LoadSanPham(this.conn);
                this.quanLyCommentBus.LoadBinhLuan(this.conn, currentUser.role);
                this.quanLySanPhamBUS.LoadSanPhamOrder(this.conn);
                this.quanLyKhachHangBus.LoadKhachHang(this.conn);
                this.dataSanPham = this.quanLySanPhamBUS.listSanPham;
                this.LoadSanPhamCallback();
                this.LoadSPOrderCallback();

                /* QUAN LY BINH LUAN */
                this.dataBinhLuan = this.quanLyCommentBus.listBinhLuan;
                this.dataKhachHang = this.quanLyKhachHangBus.listKhachHang;
                this.LoadBinhLuanCallback();

                /* QUAN LY COMMENT */
                this.tabControl.TabPages.Insert(1, this.tabPageComment);

            }else if (temp.role == DTO.Helper.Constants.USERTYPE_SALE)
            {
                /* QUAN LY SAN PHAM */
                // Load available TabPage
                this.tabControl.TabPages.Insert(0, this.tabPageSanPham);
                // Change UI
                this.listSPBill.Enabled = false;
                this.btnSPAdd.Enabled = false;
                this.btnSPImport.Enabled = false;
                //Load data
                this.quanLySanPhamBUS.LoadSanPham(this.conn);
                this.quanLySanPhamBUS.LoadSanPhamOrder(this.conn);
                this.quanLyCommentBus.LoadBinhLuan(this.conn, currentUser.role);
                this.dataSanPham = this.quanLySanPhamBUS.listSanPham;
                this.LoadSanPhamCallback();
                this.LoadSPOrderCallback();

                /* QUAN LY BINH LUAN */
                this.dataBinhLuan = this.quanLyCommentBus.listBinhLuan;
                this.dataKhachHang = this.quanLyKhachHangBus.listKhachHang;
                this.LoadBinhLuanCallback();

                /* QUAN LY COMMENT */
                this.tabControl.TabPages.Insert(1, this.tabPageComment);
            }
            else if (temp.role == DTO.Helper.Constants.USERTYPE_ADVERTISER)
            {

            }else if (temp.role == DTO.Helper.Constants.USERTYPE_SHIPPER)
            {

            }else if (temp.role == DTO.Helper.Constants.USERTYPE_TREASURER)
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
            this.LoginStatus = DTO.Helper.Constants.LOGINSTAT_NONE;
            this.currentUser = null;

            // Clear tab
            this.InitFormSetting();

            // Remove all session data
            this.selectedIndex = -1;

            /* QUAN LY SAN PHAM */
            this.dataSanPham = new List<ItemDTO>();
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
                    tempItem.BackColor = ColorTranslator.FromHtml("#f24444"); ;
                }

                if (this.dataSanPham[i].isImportOrder)
                {
                    tempItem.BackColor = ColorTranslator.FromHtml("#cccccc");
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
                ItemDTO item = this.quanLySanPhamBUS.GetItemByID(this.conn, dataBinhLuan[i].productID);
                CustomerDTO customer = quanLyKhachHangBus.loadKhachHangByID(conn, dataBinhLuan[i].customerID);
                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, item.name));
                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, customer.name));
                string status = DTO.Helper.EnumHelper.StringValueOf((DTO.Helper.MyEnum.TypeComment)this.dataBinhLuan[i].status);
                if(this.dataBinhLuan[i].handle_type == 1 && currentUser.role == DTO.Helper.Constants.USERTYPE_MANAGER)
                {
                    status += " (Đã cộng điểm)";
                }
                else if(this.dataBinhLuan[i].handle_type == 2 && currentUser.role == DTO.Helper.Constants.USERTYPE_MANAGER)
                {
                    status += " (Đã xóa)";
                }
                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, status));
                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, this.dataBinhLuan[i].detail));
                switch (this.dataBinhLuan[i].status)
                {
                    case 1: tempItem.BackColor = ColorTranslator.FromHtml("#baffb0");
                        break;
                    case 2:
                        tempItem.BackColor = ColorTranslator.FromHtml("#f24444");
                        break;
                    case 3:
                        tempItem.BackColor = ColorTranslator.FromHtml("#b0fff7");
                        break;
                }

                this.listComment.Items.Add(tempItem);
            }
        }

        public void LoadSPOrderCallback()
        {
            // Remove all current data
            this.listSPBill.Items.Clear();

            if (this.quanLySanPhamBUS.listSPOrder.Count > 0)
            {
                for (int i = 0; i < this.quanLySanPhamBUS.listSPOrder.Count; i++)
                {
                    ListViewItem tempItem = new ListViewItem(String.Format("{0:MM/dd/yyyy}", this.quanLySanPhamBUS.listSPOrder[i].date));
                    tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, this.quanLySanPhamBUS.listSPOrder[i].owner));
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
            if (this.LoginStatus == DTO.Helper.Constants.LOGINSTAT_NONE)
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

        /// <summary>
        /// Handle event click on Create new import order for SanPham
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSPCreateBill_Click(object sender, EventArgs e)
        {
            Views.CreateSanPhamImportOrder createSanPhamImportOrder = new Views.CreateSanPhamImportOrder(this, Views.CreateSanPhamImportOrder.MODE_CREATE_IMPORT, 0)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            createSanPhamImportOrder.ShowDialog();
        }

        /// <summary>
        /// Create new SanPham
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSPAdd_Click(object sender, EventArgs e)
        {
            Views.SanPhamDetail detailForm = new Views.SanPhamDetail(this)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            detailForm.ShowDialog();
        }



        private void ListSPBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.listSPBill.FocusedItem.Index;
            if (index == this.selectedBillIndex)
            {
                return;
            }
            this.selectedBillIndex = index;

            Views.CreateSanPhamImportOrder orderForm = new Views.CreateSanPhamImportOrder(this, Views.CreateSanPhamImportOrder.MODE_APPROVE, this.quanLySanPhamBUS.listSPOrder[index], index)
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

            Views.CommentDetail commentDetailForm = new Views.CommentDetail(index, this.dataBinhLuan[index], this.currentUser, this, this.conn, this.repository)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            commentDetailForm.ShowDialog();
        }

        /// <summary>
        /// Handle event btn View Statistic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCommentViewStatistic_Click(object sender, EventArgs e)
        {
            Views.CommentStatistic commentStatistic = new Views.CommentStatistic(this.repository)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            commentStatistic.ShowDialog();
        }

        private void BtnSPBillBack_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handle event when click Import SP button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSPImport_Click(object sender, EventArgs e)
        {
            Views.SanPhamImport sanPhamImport = new Views.SanPhamImport(this)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            sanPhamImport.ShowDialog();
        }
    }
}
