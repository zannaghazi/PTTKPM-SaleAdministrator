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
        public List<Models.ItemOrder> listSPOrder = new List<Models.ItemOrder>();

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
            this.listSanPham = new List<Models.Item>();
            /* DUMMY DATA */
            for (int i = 0; i < 20; i++)
            {
                string name = "Item " + i;
                Models.Item temp = new Models.Item(
                    i + 1,
                    name,
                    "Linh kien may tinh",
                    21 - i,
                    10,
                    "Viễn Sơn");
                this.listSanPham.Add(temp);
            }
        }

        public void LoadSanPhamOrder()
        {
            this.listSPOrder = new List<Models.ItemOrder>();

            /* DUMMY DATA */
            List<Models.Item> item = new List<Models.Item>();
            for (int i = 0; i < 5; i++)
            {
                string name = "Item " + i;
                Models.Item temp = new Models.Item(
                    i + 1,
                    name,
                    "Linh kien may tinh",
                    21 - i,
                    10,
                    "Viễn Sơn");
                item.Add(temp);
            }
            Models.ItemOrder temp1 = new Models.ItemOrder(
                1,
                DateTime.Now,
                "Tổng giám đốc",
                Models.ItemOrder.IMPORT,
                item,
                false);
            Models.ItemOrder temp2 = new Models.ItemOrder(
                2,
                DateTime.Now,
                "Quản lý",
                Models.ItemOrder.RETURN,
                item,
                false);

            this.listSPOrder.Add(temp1);
            this.listSPOrder.Add(temp2);
        }

        /// <summary>
        /// Add new SanPham to Database
        /// </summary>
        /// <param name="sp"></param>
        public void AddSanPham(Models.Item sp)
        {
            // TODO: Get last id
            int lastID = this.listSanPham.Count + 1;
            sp.ID = lastID;

            this.listSanPham.Add(sp);
            // TODO: Save item to DB

        }

        /// <summary>
        /// Edit SanPham
        /// </summary>
        /// <param name="index"></param>
        /// <param name="sp"></param>
        public void UpdateSanPham(int index, Models.Item sp)
        {
            this.listSanPham[index] = sp;
            // TODO: Save Sanpham to DB
        }

        /// <summary>
        /// Delete SanPham from database
        /// </summary>
        /// <param name="sp"></param>
        public void DeleteSanPham(Models.Item sp)
        {
            this.listSanPham.Remove(sp);
            // TODO: Change flat remove in DB
        }

        /// <summary>
        /// Get all Item that Amount lower than Minimum
        /// </summary>
        /// <returns></returns>
        public List<Models.Item> GetLowAmountItem()
        {
            List<Models.Item> temp = new List<Models.Item>();

            for (int i = 0; i < this.listSanPham.Count; i++)
            {
                if (this.listSanPham[i].amount < this.listSanPham[i].minimum)
                {
                    temp.Add(this.listSanPham[i]);
                }
            }

            return temp;
        }
    }
}
