using BUS;
using DAO;
using DTO;
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
        public List<QuangCaoDTO> dataQuangCao = new List<QuangCaoDTO>();
        public List<DoiTacDTO> dataDoiTac = new List<DoiTacDTO>();
        public List<QCsdtDTO> dataQCsdt = new List<QCsdtDTO>();
        public List<QCsdtDTO> selectQCsdt = new List<QCsdtDTO>();

        public List<HoaDonDTO> dataHoaDon = new List<HoaDonDTO>();
        
        // Temporary variable
        private int selectedIndex = -1;
        public int selectedBillIndex = -1;
        private int selectedCommentIndex = -1;

        public int selectedDoiTacIndex = -1;
        public int selectedQuangCaoIndex = -1;
        public int selectedQuangCaoSDTIndex = -1;

        public int selectedHoaDonIndex = -1;

        //BUS
        public LoginBUS loginBUS = new LoginBUS();
        public QuanLySanPhamBUS quanLySanPhamBUS = new QuanLySanPhamBUS();
        public QuanLyCommentBus quanLyCommentBus = new QuanLyCommentBus();
        public QuanLyKhachHangBUS quanLyKhachHangBus = new QuanLyKhachHangBUS();
        public QuanLyQuangCaoBUS quanLyQuangCaoBUS = new QuanLyQuangCaoBUS();
        public QuanLyThanhToanBUS QuanLyThanhToanBUS = new QuanLyThanhToanBUS();
        //Connection
        public Connection conn;

        private bool isReload = false;
        private bool isFirstLoad = true;



        /// <summary>
        /// Initial InitPage
        /// </summary>
        public InitPage()
        {
            this.InitializeComponent();
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

            //Fix column size for table of Comment
            int listQCSize = this.listQuangCao.Width;
            this.listQuangCao.Columns[0].Width = listQCSize / 11;
            this.listQuangCao.Columns[1].Width = listQCSize * 3 / 11;
            this.listQuangCao.Columns[2].Width = listQCSize * 5 / 11;

            //Fix column size for table of Comment
            int listDTSize = this.listDoiTac.Width;
            this.listDoiTac.Columns[0].Width = listDTSize / 11;
            this.listDoiTac.Columns[1].Width = listDTSize * 4 / 11;
            this.listDoiTac.Columns[2].Width = listDTSize * 3 / 11;
            this.listDoiTac.Columns[1].Width = listDTSize * 3 / 11;
            this.listDoiTac.Columns[2].Width = listDTSize * 3 / 11;

            //Fix column size for table of Comment
            int listQCsdtSize = this.listQCsdt.Width;
            this.listQCsdt.Columns[0].Width = listQCsdtSize * 4 / 11;
            this.listQCsdt.Columns[1].Width = listQCsdtSize * 3 / 11;
            this.listQCsdt.Columns[2].Width = listQCsdtSize * 3 / 11;


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

            this.isFirstLoad = true;
            this.isReload = false;
            this.selectedCommentIndex = -1;
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

                /* QUAN LY Quang Cao */
                this.tabControl.TabPages.Insert(2, this.tabQuangCao);

                this.quanLyQuangCaoBUS.LoadQuangCao(this.conn);
                this.quanLyQuangCaoBUS.LoadDoiTac(this.conn);
                this.quanLyQuangCaoBUS.LoadQCsdt(this.conn);

                this.dataQuangCao = this.quanLyQuangCaoBUS.listQuangCao;
                this.dataDoiTac = this.quanLyQuangCaoBUS.listDoiTac;
                this.dataQCsdt = this.quanLyQuangCaoBUS.listQCsdt;

                this.LoadQuangCaoCallback();
                this.LoadDoiTacCallback();
                this.LoadQCsdtCallback();

                /* QUAN LY Thanh Toán */
                this.tabControl.TabPages.Insert(3, this.tabThanhToan);
                this.QuanLyThanhToanBUS.LoadHoaDon(this.conn);
                this.dataHoaDon = this.QuanLyThanhToanBUS.listHoaDon;
                this.LoadHoaDonCallback();
            }
            else if (temp.role == DTO.Helper.Constants.USERTYPE_SALE)
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

                /* QUAN LY COMMENT */
                this.tabControl.TabPages.Insert(2, this.tabQuangCao);
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
            if (!this.isFirstLoad)
            {
                this.isReload = true;
            }
            this.isFirstLoad = false;

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

        public void LoadQuangCaoCallback()
        {
            // Remove all current data
            this.listQuangCao.Items.Clear();

            // Add data to list
            for (int i = 0; i < this.dataQuangCao.Count; i++)
            {
                ListViewItem tempItem = new ListViewItem(this.dataQuangCao[i].ID.ToString());

                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, this.dataQuangCao[i].TieuDe));
                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, this.dataQuangCao[i].NoiDung));
       
                if (this.dataQuangCao[i].isDeleted ==1)
                {
                    tempItem.BackColor = ColorTranslator.FromHtml("#f24444"); ;
                }
                this.listQuangCao.Items.Add(tempItem);
            }
        }

        public void LoadDoiTacCallback()
        {
            this.listDoiTac.Items.Clear();

            // Add data to list
            for (int i = 0; i < this.dataDoiTac.Count; i++)
            {
                ListViewItem tempItem = new ListViewItem(this.dataDoiTac[i].ID.ToString());

                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, this.dataDoiTac[i].Ten));
                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, this.dataDoiTac[i].NgayKyHD.ToString("dd/MM/yyyy")));
                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, this.dataDoiTac[i].NgayHetHanHD.ToString("dd/MM/yyyy")));
                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, this.dataDoiTac[i].ViTriDang));
                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, this.dataDoiTac[i].IDBaiQC.ToString()));
                if (DateTime.Compare(this.dataDoiTac[i].NgayHetHanHD,DateTime.Now) <0)
                {
                    tempItem.BackColor = ColorTranslator.FromHtml("#f24444"); ;
                }
                this.listDoiTac.Items.Add(tempItem);
            }
        }

        public void LoadQCsdtCallback()
        {
            this.listQCsdt.Items.Clear();

            // Add data to list
            for (int i = 0; i < this.dataQCsdt.Count; i++)
            {
                ListViewItem tempItem = new ListViewItem(this.dataQCsdt[i].name);

                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, this.dataQCsdt[i].sdt));
                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, this.dataQCsdt[i].dateqc));
                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, this.dataQCsdt[i].IDBaiQC.ToString()));
                if (this.dataQCsdt[i].dateqc == null)
                {
                    tempItem.BackColor = ColorTranslator.FromHtml("#f24444"); ;
                }
                this.listQCsdt.Items.Add(tempItem);
            }
        }

        public void LoadHoaDonCallback()
        {
            this.listHoaDon.Items.Clear();

            // Add data to list
            for (int i = 0; i < this.dataHoaDon.Count; i++)
            {
                ListViewItem tempItem = new ListViewItem(this.dataHoaDon[i].ID.ToString());

                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, this.dataHoaDon[i].TenKhach));
                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, this.dataHoaDon[i].TenNV));
                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, this.dataHoaDon[i].Ngay.ToString("dd/MM/yyyy")));
                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, this.dataHoaDon[i].Gia));
                if (this.dataHoaDon[i].TrangThai == 0)
                {
                    tempItem.BackColor = ColorTranslator.FromHtml("#f24444"); ;
                }
                this.listHoaDon.Items.Add(tempItem);
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
                this.selectedIndex = -1;
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
                this.selectedBillIndex = -1;
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
                this.selectedCommentIndex = -1;
                return;
            }

            if (this.isReload)
            {
                this.isReload = false;
                return;
            }
            this.selectedCommentIndex = index;

            Views.CommentDetail commentDetailForm = new Views.CommentDetail(index, this.dataBinhLuan[index], this.currentUser, this, this.conn)
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
            Views.CommentStatistic commentStatistic = new Views.CommentStatistic()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            commentStatistic.ShowDialog();
        }

        private void BtnSPBillBack_Click(object sender, EventArgs e)
        {
            Views.GuaranteeOrder guaranteeOrder = new Views.GuaranteeOrder(this)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            guaranteeOrder.ShowDialog();
        }

        /// <summary>
        /// Handle event when click Import SP button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSPImport_Click(object sender, EventArgs e)
        {
            Views.GuaranteeSanPham baohanh = new Views.GuaranteeSanPham(this)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            baohanh.ShowDialog();
        }


        

        private void button1_Click(object sender, EventArgs e)
        {
            Views.TaoQuangCao TaoQuangCao = new Views.TaoQuangCao(this)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            TaoQuangCao.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int IDBaiQC = Int16.Parse(this.textID.Text);
            Views.CreateDoiTac CreateDoiTac = new Views.CreateDoiTac(this, IDBaiQC)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            CreateDoiTac.ShowDialog();
        }

        private void listDoiTac_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.listDoiTac.FocusedItem.Index;
            if (index == this.selectedDoiTacIndex)
            {
                this.selectedDoiTacIndex = -1;
                return;
            }
            this.selectedDoiTacIndex = index;
            Views.CreateDoiTac detailForm = new Views.CreateDoiTac(index, this.dataDoiTac[index], this)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            detailForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Views.QuangCaoSDT QuangCaoSDT = new Views.QuangCaoSDT(this)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            QuangCaoSDT.ShowDialog();
        }
        public int IDBaiQC=-1;
        private void listQuangCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.listQuangCao.FocusedItem.Index;
            if (index == this.selectedQuangCaoIndex)
            {
                this.selectedQuangCaoIndex = -1;
                return;
            }
            this.selectedQuangCaoIndex = index;
            this.IDBaiQC = this.dataQuangCao[index].ID;
            this.textID.Text = this.dataQuangCao[index].ID.ToString();
            this.textTieuDe.Text = this.dataQuangCao[index].TieuDe;
        }


        private void listQCsdt_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.listQCsdt.FocusedItem.Index;
            if (index == this.selectedQuangCaoSDTIndex)
            {
                this.selectedQuangCaoSDTIndex = -1;
                return;
            }
            if (this.dataQCsdt[index].dateqc != null)
            {
                this.selectedQuangCaoSDTIndex = -1;
                return;
            }
            this.selectedQuangCaoSDTIndex = index;
            if (this.listQCsdt.Items[index].BackColor == ColorTranslator.FromHtml("#fff700"))
            {
                this.selectQCsdt.Remove(this.dataQCsdt[index]);
                this.listQCsdt.Items[index].BackColor = ColorTranslator.FromHtml("#f24444");
            }
            else
            {
                this.selectQCsdt.Add(this.dataQCsdt[index]);
                this.listQCsdt.Items[index].BackColor = ColorTranslator.FromHtml("#fff700");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Views.LichSuQC LichSuQC = new Views.LichSuQC(this)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            LichSuQC.ShowDialog();
        }

        private void listHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.listHoaDon.FocusedItem.Index;
            if (index == this.selectedHoaDonIndex)
            {
                this.selectedHoaDonIndex = -1;
                return;
            }
            if (this.dataHoaDon[index].TrangThai == 1)
            {
                this.selectedHoaDonIndex = -1;
                return;
            }
            this.selectedHoaDonIndex = index;
            this.textBoxID.Text = this.dataHoaDon[index].ID.ToString();
            this.textBoxTenKhach.Text = this.dataHoaDon[index].TenKhach;
            this.textBoxTenNV.Text = this.dataHoaDon[index].TenNV;
            this.textBoxNgay.Text = this.dataHoaDon[index].Ngay.ToString("dd/MM/yyyy");
            this.textBoxGia.Text = this.dataHoaDon[index].Gia;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            this.QuanLyThanhToanBUS.EDITHoaDon(this.conn, Int16.Parse(this.textBoxID.Text) );
            this.dataHoaDon = this.QuanLyThanhToanBUS.listHoaDon;
            this.LoadHoaDonCallback();
        }
    }
}
