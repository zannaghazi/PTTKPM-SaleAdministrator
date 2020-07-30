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

namespace QuanLyBanHang.Views
{
    public partial class SanPhamImport : Form
    {
        private List<ItemOrderDTO> data = new List<ItemOrderDTO>();
        private InitPage parent;
        public SanPhamImport()
        {
            this.InitializeComponent();
            this.InitSetting();
        }

        public SanPhamImport(InitPage parent)
        {
            this.InitializeComponent();
            this.parent = parent;
            this.InitSetting();
            
        }

        private void InitSetting()
        {
            int listSPSize = this.listSanPham.Width;
            this.listSanPham.Columns[0].Width = listSPSize / 8;
            this.listSanPham.Columns[1].Width = listSPSize * 3 / 8;
            this.listSanPham.Columns[2].Width = listSPSize * 3 / 8;
            this.listSanPham.Columns[3].Width = listSPSize * 2 / 8;

            this.data = this.parent.quanLySanPhamDomain.LoadApprovedImport(this.parent.repository);

            for (int i = 0; i < this.data.Count; i++)
            {
                this.cbOrder.Items.Add(this.data[i].owner);
            }
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
