using DTO;
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
    public partial class QuangCaoSDT : Form
    {
        private InitPage parent = new InitPage();
        public List<QCsdtDTO> selectQCsdt = new List<QCsdtDTO>();
        public QuangCaoSDT(InitPage parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.selectQCsdt = this.parent.selectQCsdt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.selectQCsdt.Count != 0 && this.parent.IDBaiQC != -1)
            {
                this.parent.quanLyQuangCaoBUS.AddQCSDT(this.parent.conn, this.selectQCsdt, this.parent.IDBaiQC);
            }
            this.parent.dataQCsdt = this.parent.quanLyQuangCaoBUS.listQCsdt;
            this.parent.LoadQCsdtCallback();
            this.Close();

        }
    }
}
