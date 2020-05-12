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
        private InitPage parent = new InitPage();
        private int itemIndex = -1;

        /// <summary>
        /// Default constructor
        /// </summary>
        public CommentDetail()
        {
            this.InitializeComponent();
        }

        public CommentDetail(int index, Models.Comment comment, Models.User currentUser, Models.Customer customer, Models.Item item,  InitPage parent)
        {
            this.parent = parent;
            this.itemIndex = index;
            this.InitializeComponent();
            this.txtID.Text = comment.ID.ToString();
            this.txtSPName.Text = item.name;
            this.txtCustomerName.Text = customer.name;
            this.textBoxEmail.Text = customer.email;
            this.textBoxAddress.Text = customer.address;
            this.cbStatus.Text = MyEnum.EnumHelper.StringValueOf((MyEnum.MyEnum.TypeComment)comment.status);
            this.txtComment.Text = comment.detail;

            if (currentUser.role == Constants.USERTYPE_MANAGER)
            {
                this.btnScore.Visible = true;
                this.btnDelete.Visible = true;
            }
            else
            {
                this.btnScore.Visible = false;
                this.btnDelete.Visible = false;
            }

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
