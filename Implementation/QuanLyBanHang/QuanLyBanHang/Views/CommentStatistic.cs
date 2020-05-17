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
    public partial class CommentStatistic : Form
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public CommentStatistic()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Setting for form
        /// </summary>
        public void InitFormSetting()
        {
            this.pbBad.Maximum = 100;
            this.pbClassifed.Maximum = 100;
            this.pbGood.Maximum = 100;
            this.pbNone.Maximum = 100;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
