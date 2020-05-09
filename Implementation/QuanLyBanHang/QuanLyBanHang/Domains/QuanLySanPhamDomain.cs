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
                    i + 1,
                    name,
                    "Linh kien may tinh",
                    21 - i,
                    10);
                this.listSanPham.Add(temp);
            }
        }

        public void AddSanPham(Models.Item sp)
        {
            // TODO: Get last id
            int lastID = this.listSanPham.Count + 1;
            sp.ID = lastID;

            this.listSanPham.Add(sp);
            // TODO: Save item to DB

        }

        /// <summary>
        /// Chinh sua san pham trong danh sach
        /// </summary>
        /// <param name="index"></param>
        /// <param name="sp"></param>
        public void UpdateSanPham(int index, Models.Item sp)
        {
            this.listSanPham[index] = sp;
            // TODO: Save Sanpham to DB
        }

        public void DeleteSanPham(Models.Item sp)
        {
            this.listSanPham.Remove(sp);
            // TODO: Change flat remove in DB
        }
    }
}
