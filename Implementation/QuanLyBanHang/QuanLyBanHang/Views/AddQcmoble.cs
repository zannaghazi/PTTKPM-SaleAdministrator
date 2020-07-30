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
    public partial class AddQcmoble : Form
    {
        public static readonly int MODE_APPROVE = 2;
        private InitPage parent = new InitPage();
        private List<Models.QangCaoSDT> dsDaQC = new List<Models.QangCaoSDT>();
        private List<Models.Customer> dsChuaQC = new List<Models.Customer>();
        private List<Models.Item> dsSP= new List<Models.Item>();
        private int mode = 0;
        int idSP = -1;

        public AddQcmoble()
        {
            this.InitializeComponent();
        }
        public AddQcmoble(InitPage parent)
        {
            this.InitializeComponent();
            this.parent = parent;
            dsDaQC = parent.quanLyQuangCaoDomain.listQCSDT;
            dsChuaQC = parent.quanLyKhachHangDomain.listKhachHang;
            dsSP = parent.quanLySanPhamDomain.listSanPham;
            this.InitSetting();
            this.LoadData();
        }

      

        private void InitSetting()
        {
            int listQCSize = this.listQC.Width;
            this.listQC.Columns[0].Width = listQCSize / 8;
            this.listQC.Columns[1].Width = listQCSize * 3 / 8;
            this.listQC.Columns[2].Width = listQCSize * 3 / 8;

        }

        private void LoadData()
        {
         
            for (int i = 0; i < this.dsChuaQC.Count; i++)
            {
                if (String.Compare(this.dsChuaQC[i].sdt, "0", true)!=0)
                {
                    for (int j = 0; j < this.dsDaQC.Count; j++)
                    {
                        if(this.dsChuaQC[i].ID !=(this.dsDaQC[j].id_customer+1))
                        {
                            ListViewItem temp = new ListViewItem(this.dsChuaQC[i].ID.ToString());
                            temp.SubItems.Add(new ListViewItem.ListViewSubItem(temp, this.dsChuaQC[i].name));
                            temp.SubItems.Add(new ListViewItem.ListViewSubItem(temp, this.dsChuaQC[i].sdt));
                            this.listQC.Items.Add(temp);
                            break;
                        }
                       
                       
                    }
                }
            }
            cbSP.DisplayMember = "Text";
            cbSP.ValueMember = "Value";
            for (int i = 0; i < this.dsSP.Count; i++)
            {
                cbSP.Items.Add(new { Text = dsSP[i].name , Value = dsSP[i].ID });
            }
           
                

            if (this.mode == MODE_APPROVE)
            {
                for (int i = 0; i < this.listQC.Items.Count; i++)
                {
                    this.listQC.Items[i].Checked = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < this.listQC.Items.Count; i++)
            {
                this.listQC.Items[i].Checked = true;
            }
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listQC.Items.Count; i++)
            {
                this.listQC.Items[i].Checked = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
           
                // Get all selected Item
                List<Models.Customer> selectedCS = new List<Models.Customer>();
                for (int i = 0; i < this.listQC.Items.Count; i++)
                {
                    if (this.listQC.Items[i].Checked)
                    {
                  
                    Int32 a = Int32.Parse(this.listQC.Items[i].Text)-1;
                        selectedCS.Add(this.dsChuaQC[a]);
                    }
                }
                ////////////////////gán mặt đinh hàng quảng cáo có id : 1
                /////////////fix combobox
              this.parent.quanLyQuangCaoDomain.AddQCmobile(this.parent.repository, selectedCS, 1 ,this.parent);

            this.Close();
        }

        private void cbSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            /////////////fix combobox
            String aa = cbSP.Text;
            var b = cbSP.SelectedItem;
            
            
        }
    }
}
