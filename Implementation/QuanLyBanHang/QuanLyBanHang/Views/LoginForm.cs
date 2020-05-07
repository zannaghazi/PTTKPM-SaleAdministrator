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
        /// <summary>
        /// Constructor of Login Form
        /// </summary>
        public LoginForm()
        {
            this.InitializeComponent();
            this.InitSetting();
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
            }
        }
    }
}
