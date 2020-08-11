using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Windows.Forms;
using DAO;
using DTO;

namespace BUS
{
    public class QuanLySanPhamBUS
    {
        public ItemDAO itemDAO;
        public ItemOrderDAO itemOrderDAO;
        public List<ItemDTO> listSanPham = new List<ItemDTO>();
        public List<ItemOrderDTO> listSPOrder = new List<ItemOrderDTO>();

        /// <summary>
        /// Constructor
        /// </summary>
        public QuanLySanPhamBUS()
        {
            itemDAO = new ItemDAO();
            itemOrderDAO = new ItemOrderDAO();
        }

        /// <summary>
        /// Load data of SanPham from Database
        /// </summary>
        public void LoadSanPham(Connection conn)
        {
            this.listSanPham = new List<ItemDTO>();
            this.listSanPham = itemDAO.getAllItem(conn);
        }

        public void LoadSanPhamOrder(Connection conn)
        {
            this.listSPOrder = this.itemOrderDAO.getAllItemOrder(conn);
        }

        public ItemDTO GetItemByID(Connection conn, int id)
        {
            return this.itemDAO.getItemByID(conn, id);
        }

        /// <summary>
        /// Add new SanPham to Database
        /// </summary>
        /// <param name="sp"></param>
        public void AddSanPham(Connection conn, ItemDTO sp)
        {
            this.listSanPham = this.itemDAO.AddItem(conn, sp);
            if (this.listSanPham == null)
            {
                MessageBox.Show(
                   "Có lỗi xảy ra trong quá trình thêm dữ liệu, vui lòng thử lại!",
                   "Lỗi",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }else
            {
                this.LoadSanPham(conn);
            }
        }

        /// <summary>
        /// Edit SanPham
        /// </summary>
        /// <param name="index"></param>
        /// <param name="sp"></param>
        public void UpdateSanPham(Connection conn, ItemDTO sp)
        {
            if (this.itemDAO.UpdateItem(conn, sp))
            {
                this.LoadSanPham(conn);
            }else
            {
                MessageBox.Show(
                    "Có lỗi xảy ra trong quá trình cập nhật dữ liệu, vui lòng thử lại!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete SanPham from database
        /// </summary>
        /// <param name="sp"></param>
        public void DeleteSanPham(Connection conn, ItemDTO sp)
        {
            if (this.itemDAO.DeleteItem(conn, sp))
            {
                this.listSanPham.Remove(sp);
            }else
            {
                MessageBox.Show(
                    "Có lỗi xảy ra trong quá trình cập nhật dữ liệu, vui lòng thử lại!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public void AddSanPhamAfterApproveOrder(Connection conn, List<ItemDTO> sp)
        {
            for (int i = 0; i < sp.Count; i++)
            {
                sp[i].amount += sp[i].minimum;
                itemDAO.UpdateItem(conn, sp[i]);
            }
        }

        /// <summary>
        /// Update import order
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="data"></param>
        public void UpdateItemOrder(Connection conn, ItemOrderDTO data)
        {
           if (this.itemOrderDAO.UpdateItemOrder(conn, data))
           {
                this.LoadSanPhamOrder(conn);
           }else
           {
                MessageBox.Show(
                    "Có lỗi xảy ra trong quá trình cập nhật dữ liệu, vui lòng thử lại!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
           }
        }

        /// <summary>
        /// Delete the order
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="data"></param>
        public void DeleteItemOrder(Connection conn, ItemOrderDTO data)
        {
            if (this.itemOrderDAO.DeleteItemOrder(conn, data))
            {
                this.LoadSanPhamOrder(conn);
            }else
            {
                MessageBox.Show(
                    "Có lỗi xảy ra trong quá trình cập nhật dữ liệu, vui lòng thử lại!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Get all Item that Amount lower than Minimum
        /// </summary>
        /// <returns></returns>
        public List<ItemDTO> GetLowAmountItem(ItemDAO dao, Connection conn)
        {
            List<ItemDTO> list = dao.getLowAmountItem(conn);

            if (list.Count == 0)
            {
                MessageBox.Show(
                    "Data chưa có dữ liệu",
                    "Lỗi",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }
            return list;
        }

        /// <summary>
        /// Add SanPham's Import Order to DB
        /// </summary>
        /// <param name="repository"></param>
        public void AddSanPhamImportOrder(Connection conn, ItemOrderDTO data)
        {
            if (this.itemOrderDAO.AddItemOrder(conn, data))
            {
                this.LoadSanPhamOrder(conn);
            }
            else {
                MessageBox.Show(
                    "Có lỗi xảy ra trong quá trình thêm dữ liệu, vui lòng thử lại!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /*  NHAP HANG */
        public List<ItemOrderDTO> LoadApprovedImport(Connection conn)
        {
            List<ItemOrderDTO> temp = this.itemOrderDAO.LoadApprovedImport(conn);
            for (int i = 0; i < this.listSPOrder.Count; i++)
            {
                string[] listSPID = temp[i].listItemID.Trim().Split(' ');
                List<ItemDTO> listOrderItem = new List<ItemDTO>();
                for (int j = 0; j < listSPID.Length; j++)
                {
                    if (this.GetItemByID(conn, Convert.ToInt32(listSPID[j])).ID != -1)
                    {
                        listOrderItem.Add(this.GetItemByID(conn, Convert.ToInt32(listSPID[j])));
                    }
                }
                temp[i].listSP = listOrderItem;
            }
            return temp;
        }
    }
}
