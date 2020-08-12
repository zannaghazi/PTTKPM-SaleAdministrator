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
using DAO;

namespace QuanLyBanHang.Views
{
    public partial class CommentDetail : Form
    {
        private InitPage parent = new InitPage();
        private int itemIndex = -1;
        private int statusBefore = -1;
        CustomerDTO currentCustomer = null;
        private CommentDTO comment = null;

        /// <summary>
        /// Default constructor
        /// </summary>
        public CommentDetail()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="index">index of comment</param>
        /// <param name="comment">comment</param>
        /// <param name="currentUser">current user</param>
        /// <param name="customer">person comment</param>
        /// <param name="item">product comment</param>
        /// <param name="parent">parent layout</param>
        public CommentDetail(int index, CommentDTO comment, UserDTO currentUser, InitPage parent, Connection conn)
        {
            ItemDTO item = new QuanLySanPhamBUS().GetItemByID(conn, comment.productID);
            this.comment = comment;
            CustomerDTO customer = new QuanLyKhachHangBUS().loadKhachHangByID(conn, comment.customerID);
            this.parent = parent;
            this.itemIndex = index;
            this.InitializeComponent();
            this.txtID.Text = comment.ID.ToString();
            this.txtSPName.Text = item.name;
            this.txtCustomerName.Text = customer.name;
            this.textBoxEmail.Text = customer.email;
            this.textBoxAddress.Text = customer.address;
            this.cbStatus.Text = DTO.Helper.EnumHelper.StringValueOf((DTO.Helper.MyEnum.TypeComment)comment.status);
            this.txtComment.Text = comment.detail;
            statusBefore = comment.status;
            currentCustomer = customer;
            verifyButton();   
        }

        /// <summary>
        /// verify Button
        /// </summary>
       public void verifyButton()
        {
            if (this.parent.currentUser.role == DTO.Helper.Constants.USERTYPE_MANAGER)
            {
                this.btnScore.Visible = true;
                this.btnDelete.Visible = true;
                if (comment.handle_type != 0)
                {
                    this.btnScore.Enabled = false;
                    this.btnDelete.Enabled = false;
                }
            }
            else
            {
                this.btnScore.Visible = false;
                this.btnDelete.Visible = false;
            }

            if (comment.status > 0)
            {
                this.cbStatus.Enabled = false;
            }
            this.buttonConfirm.Enabled = false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            string status = this.cbStatus.Text;
            int id = Int32.Parse(this.txtID.Text);
            this.parent.quanLyCommentBus.UpdateStatus(this.parent.conn, this.comment, (int)DTO.Helper.EnumHelper.GetValueFromDescription<DTO.Helper.MyEnum.TypeComment>(status), this.parent.currentUser.role);
            this.parent.dataBinhLuan = this.parent.quanLyCommentBus.listBinhLuan;
            this.parent.LoadBinhLuanCallback();
            this.Close();
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string status = this.cbStatus.Text;
            int value = (int)DTO.Helper.EnumHelper.GetValueFromDescription< DTO.Helper.MyEnum.TypeComment>(status);
            if (value != statusBefore && value != 0)
            {
                this.buttonConfirm.Enabled = true;
            }
            else
            {
                this.buttonConfirm.Enabled = false;
            }
        }

        private void btnScore_Click(object sender, EventArgs e)
        {
            this.parent.quanLyKhachHangBus.tangDiem(this.parent.conn, currentCustomer.ID);
            this.parent.quanLyCommentBus.handleMark(this.parent.conn, this.comment, 1, this.parent.currentUser.role);
            verifyButton();
            this.parent.LoadBinhLuanCallback();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.parent.quanLyCommentBus.XoaBinhLuan(this.parent.conn, this.comment);
            this.parent.quanLyCommentBus.handleMark(this.parent.conn, this.comment, 2, this.parent.currentUser.role);
            this.parent.quanLyKhachHangBus.banNguoiDung(this.parent.conn, currentCustomer.ID);
            verifyButton();
            this.parent.LoadBinhLuanCallback();
        }
    }
}
