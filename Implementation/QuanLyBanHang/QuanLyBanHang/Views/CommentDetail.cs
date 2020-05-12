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
    public partial class CommentDetail : Form
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public CommentDetail()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handle event when click in Cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
