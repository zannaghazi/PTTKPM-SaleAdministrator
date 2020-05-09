using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Domains
{
    /// <summary>
    /// Domain layer for feature "QuanLySanPham"
    /// </summary>
    public class QuanLySanPhamDomain
    {
        public List<Models.Item> listSanPham = new List<Models.Item>();

        /// <summary>
        /// Constructor
        /// </summary>
        public QuanLySanPhamDomain()
        {

        }

        /// <summary>
        /// Load data of SanPham from Database
        /// </summary>
        public void LoadSanPham()
        {
            /* DUMMY DATA */
            for (int i = 0; i < 20; i++)
            {
                string name = "Item " + i;
                Models.Item temp = new Models.Item(
                    i + 2,
                    name,
                    "Linh kien may tinh",
                    21 - i,
                    10);
                this.listSanPham.Add(temp);
            }
        }
    }
}
