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
    public partial class LichSuQC : Form
    {
        private InitPage parent = new InitPage();
        public List<QCsdtDTO> dataQCsdt = new List<QCsdtDTO>();
        public LichSuQC(InitPage parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        public void LoadQCsdtCallback()
        {
            this.listQCsdt.Items.Clear();

            // Add data to list
            for (int i = 0; i < this.dataQCsdt.Count; i++)
            {
                ListViewItem tempItem = new ListViewItem(this.dataQCsdt[i].name);

                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, this.dataQCsdt[i].sdt));
                tempItem.SubItems.Add(new ListViewItem.ListViewSubItem(tempItem, this.dataQCsdt[i].dateqc));
                if (this.dataQCsdt[i].dateqc == null)
                {
                    tempItem.BackColor = ColorTranslator.FromHtml("#f24444"); ;
                }
                this.listQCsdt.Items.Add(tempItem);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int day = comboBox1.SelectedIndex;
            this.parent.quanLyQuangCaoBUS.LoadQCsdtLS(this.parent.conn, (day+1)*7);
            this.dataQCsdt = this.parent.quanLyQuangCaoBUS.listQCsdtLS;
            this.LoadQCsdtCallback();
        }

        
    }
}
