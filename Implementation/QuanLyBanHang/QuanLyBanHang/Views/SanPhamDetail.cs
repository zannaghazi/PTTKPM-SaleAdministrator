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
    public partial class SanPhamDetail : Form
    {
        private Models.Item data = new Models.Item();
        public SanPhamDetail()
        {
            this.InitializeComponent();
        }

        public SanPhamDetail(Models.Item item)
        {
            this.InitializeComponent();
            this.data = item;
            this.lbName.Text = item.name;
            this.txtID.Text = item.ID.ToString();
            this.txtName.Text = item.name;
            this.txtType.Text = item.type;
            this.txtAmount.Text = item.amount.ToString();
            this.txtMinimum.Text = item.minimum.ToString();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
