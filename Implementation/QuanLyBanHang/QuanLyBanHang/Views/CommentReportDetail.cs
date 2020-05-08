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
    public partial class CommentReportDetail : Form
    {
        public CommentReportDetail()
        {
            this.InitializeComponent();
            this.FormSetting();
        }
        public void FormSetting()
        {
            int listCMTSize = this.listComment.Width;
            this.listComment.Columns[0].Width = listCMTSize / 11;
            this.listComment.Columns[1].Width = listCMTSize * 3 / 11;
            this.listComment.Columns[2].Width = listCMTSize * 3 / 11;
            this.listComment.Columns[3].Width = listCMTSize * 2 / 11;
            this.listComment.Columns[4].Width = listCMTSize * 2 / 11;
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
