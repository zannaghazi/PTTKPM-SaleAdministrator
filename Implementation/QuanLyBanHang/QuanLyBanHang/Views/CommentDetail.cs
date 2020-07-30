﻿using QuanLyBanHang.Domains;
using QuanLyBanHang.Models;
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
        Customer currentCustomer = null;

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
        public CommentDetail(int index, Models.Comment comment, UserDTO currentUser, InitPage parent, Connection conn, Repository.Repository repository)
        {
            ItemDTO item = new QuanLySanPhamBUS().GetItemByID(conn, comment.productID);
            Models.Customer customer = new QuanLyKhachHangDomain().GetCustomerByID(repository, comment.customerID);
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
            statusBefore = comment.status;
            currentCustomer = customer;

            if (currentUser.role == Constants.USERTYPE_MANAGER)
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

            if(comment.status > 0)
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
            this.parent.quanLyBinhLuanDomain.UpdateBinhluan(this.parent.repository, (int)MyEnum.EnumHelper.GetValueFromDescription<MyEnum.MyEnum.TypeComment>(status),id, this.parent.currentUser.role);
            this.parent.dataBinhLuan = this.parent.quanLyBinhLuanDomain.listBinhLuan;
            this.parent.LoadBinhLuanCallback();
            this.Close();
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string status = this.cbStatus.Text;
            int value = (int)MyEnum.EnumHelper.GetValueFromDescription<MyEnum.MyEnum.TypeComment>(status);
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
            int id = Int32.Parse(this.txtID.Text);
            this.parent.quanLyKhachHangDomain.tangDiem(this.parent.repository, currentCustomer.ID);
            this.parent.quanLyBinhLuanDomain.handleMark(this.parent.repository, 1, id, this.parent.currentUser.role);
        }
    }
}
