using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class InitPage : Form
    {
        /* VARIABLES */
        private int LoginStatus = Constants.LOGINSTAT_NONE; // Login status
        private Models.User currentUser = null; // Logged user
        // TabPage
        private TabPage tabPageSanPham = null;
        private TabPage tabPageComment = null;
        private TabPage tabPageQuangCao = null;
        private TabPage tabPageDatHang = null;
        private TabPage tabPageThanhToan = null;


        /// <summary>
        /// Initial InitPage
        /// </summary>
        public InitPage()
        {
            this.InitializeComponent();
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
                this.tabControl.TabPages.Insert(1, this.tabPageComment);

                // Init domain
                Domains.QuanLySanPhamDomain quanLySanPhamDomain = new Domains.QuanLySanPhamDomain();
                //Load data
                quanLySanPhamDomain.LoadSanPham();
                // Add data to list
                for (int i = 0; i < quanLySanPhamDomain.listSanPham.Count; i++)
                {
                    ListViewItem tempItem = new ListViewItem(quanLySanPhamDomain.listSanPham[i].ID.ToString());

                    tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, quanLySanPhamDomain.listSanPham[i].name));
                    tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, quanLySanPhamDomain.listSanPham[i].type));
                    tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, quanLySanPhamDomain.listSanPham[i].amount.ToString()));
                    tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, quanLySanPhamDomain.listSanPham[i].minimum.ToString()));

                    this.listSanPham.Items.Add(tempItem);
                }

                /* QUAN LY COMMENT */
                this.listCommentRep.Enabled = true;

            }else if (temp.role == Constants.USERTYPE_SALE)
            {

            }else if (temp.role == Constants.USERTYPE_ADVERTISER)
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
            Views.CommentReportDetail dialog = new Views.CommentReportDetail();
            dialog.StartPosition = FormStartPosition.CenterParent;
            dialog.ShowDialog();
        }
    }
}
