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
    public partial class LoginForm : Form
    {
        public Models.User currentUser = new Models.User();
        private InitPage parent;

        /// <summary>
        /// Constructor of Login Form
        /// </summary>
        public LoginForm(InitPage parent)
        {
            this.InitializeComponent();
            this.InitSetting();
            this.parent = parent;
        }

        /// <summary>
        /// Configuration setting of Login form
        /// </summary>
        public void InitSetting()
        {
            this.txtPassword.PasswordChar = '*'; // Set inputed password char to '*'
        }

        /// <summary>
        /// Handle event click button Cancle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handle event click button Login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.txtUserName.Text)
                || String.IsNullOrWhiteSpace(this.txtPassword.Text))
            {
                this.lbMessage.Text = "Tên đăng nhập hoặc mật khẩu đang bị bỏ trống";
                return;
            }

            this.currentUser = this.currentUser.checkLogin(
                this.parent.repository,
                this.txtUserName.Text.Trim(),
                this.txtPassword.Text.Trim());
            if (this.currentUser.name != null) {
                this.parent.LoginCallback(this.currentUser);
                this.Close();
            }else
            {
                this.lbMessage.Text = "Tên đăng nhập hoặc mật khẩu không chính xác";
                return;
            }
        }

        /// <summary>
        /// Handle user press Enter after input password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnLogin.PerformClick();
            }
        }
    }
}
