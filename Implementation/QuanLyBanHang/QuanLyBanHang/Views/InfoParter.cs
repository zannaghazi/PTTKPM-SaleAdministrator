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
    public partial class InfoParter : Form
    {
        private InitPage parent = new InitPage();
        private int itemIndex = -1;
        private int OpenMode = 0;

        private static readonly int MODE_ADD = 0;
        private static readonly int MODE_EDIT = 1;

        public InfoParter(InitPage parent)
        {
            this.InitializeComponent();
            this.txtID.Enabled = false;
            this.OpenMode = MODE_ADD;
            this.parent = parent;
        }

        public InfoParter(int index, Models.Partner Partner, InitPage parent)
        {
            this.parent = parent;
            this.itemIndex = index;
            this.OpenMode = MODE_EDIT;

            this.InitializeComponent();
            this.txtID.Text = Partner.ID.ToString();
            this.txtName.Text = Partner.partner_name;
            this.txtInfo.Text = Partner.infopost;
            this.beginDate.Text = Partner.begindate.ToString();
            this.deadline.Text = Partner.deadline.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Models.Partner temp = null;
            try
            {
                int id = -1;
                if (!String.IsNullOrWhiteSpace(this.txtID.Text))
                {
                    id = Int32.Parse(this.txtID.Text.Trim());
                }
                temp = new Models.Partner(
                    id,
                    this.txtName.Text.Trim(),
                    this.beginDate.Value,
                    this.deadline.Value,
                    this.txtInfo.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã có dữ liệu sai định dạng!\nLàm ơn kiểm tra và lưu lại",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
            if (temp != null)
            {
                if (this.OpenMode == MODE_EDIT)
                {
                    this.parent.quanLyQuangCaoDomain.UpdatePartner(this.parent.repository, temp);
                    this.parent.dataPartner = this.parent.quanLyQuangCaoDomain.listPartner;
                    this.parent.LoadPartnerCallback();
                }
               else
                {
                   this.parent.quanLyQuangCaoDomain.AddPartner(this.parent.repository, temp);
                    this.parent.dataPartner = this.parent.quanLyQuangCaoDomain.listPartner;
                    this.parent.LoadPartnerCallback();
              }
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Đã có dữ liệu sai định dạng!\nLàm ơn kiểm tra và lưu lại",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
