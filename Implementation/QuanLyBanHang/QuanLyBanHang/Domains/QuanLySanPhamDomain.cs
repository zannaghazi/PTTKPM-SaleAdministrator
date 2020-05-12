using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Windows.Forms;

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
        /// find name in list product by id
        /// </summary>
        /// <param name="id">Id to find name of product</param>
        /// <returns></returns>
        public Models.Item findProductByID(int id)
        {
            foreach (Models.Item product in this.listSanPham)
            {
                if (product.ID == id)
                    return product;
            }
            return null;
        }

        /// <summary>
        /// Load data of SanPham from Database
        /// </summary>
        public void LoadSanPham(Repository.Repository repository)
        {
            this.listSanPham = new List<Models.Item>();

            string queryString = "select* from Item where isDeleted = false and isRequestImport = false";
            repository.cmd.CommandText = queryString;

            using (DbDataReader reader = repository.cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    MessageBox.Show(
                        "Data chưa có dữ liệu",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }else
                {
                    while (reader.Read())
                    {
                        Models.Item temp = new Models.Item(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetInt64(3),
                            reader.GetInt64(4),
                            reader.GetString(5),
                            reader.GetBoolean(6));
                        this.listSanPham.Add(temp);
                    }

                }
            }
        }

        public void LoadSanPhamOrder(Repository.Repository repository)
        {
            this.listSPOrder = new List<Models.ItemOrder>();

            string queryString = "select* from ItemOrder where isApproved = false";
            repository.cmd.CommandText = queryString;

            using (DbDataReader reader = repository.cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    return;
                }
                else
                {
                    while (reader.Read())
                    {
                        Models.ItemOrder temp = new Models.ItemOrder(
                            reader.GetDateTime(1),
                            reader.GetString(2),
                            reader.GetInt32(3),
                            reader.GetString(4),
                            reader.GetBoolean(5));
                        this.listSPOrder.Add(temp);
                    }

                }
            }
            for (int i = 0; i < this.listSPOrder.Count; i++)
            {
                string[] listSPID = this.listSPOrder[i].listItemID.Split(' ');
                List<Models.Item> listOrderItem = new List<Models.Item>();
                for (int j = 0; j < listSPID.Length; j++)
                {
                    if (this.GetItemByID(repository, Convert.ToInt32(listSPID[j])).ID != -1)
                    {
                        listOrderItem.Add(this.GetItemByID(repository, Convert.ToInt32(listSPID[j])));
                    }
                }
                this.listSPOrder[i].listSP = listOrderItem;
            }
        }

        public Models.Item GetItemByID(Repository.Repository repository, int id)
        {
            string queryString = "select* from Item where id=" + id;
            repository.cmd.CommandText = queryString;

            using (DbDataReader reader = repository.cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    return new Models.Item();
                }
                else
                {
                    Models.Item temp = new Models.Item();
                    while (reader.Read())
                    {
                        temp = new Models.Item(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetInt64(3),
                            reader.GetInt64(4),
                            reader.GetString(5),
                            reader.GetBoolean(6));
                        break;
                    }
                    return temp;
                }
            }
        }

        /// <summary>
        /// Add new SanPham to Database
        /// </summary>
        /// <param name="sp"></param>
        public void AddSanPham(Repository.Repository repository, Models.Item sp)
        {
            string queryString = "insert into Item(name, type, amount, minimum, provider, isRequestImport, isDeleted) " +
                "values('" + sp.name +
                "', '" + sp.type +
                "', " + sp.amount +
                ", " + sp.minimum +
                ", '" + sp.provider +
                "', false, false)";
            repository.cmd.CommandText = queryString;
            try
            {
                repository.cmd.ExecuteNonQuery();
            }catch(Exception ex)
            {
                MessageBox.Show(
                    "Có lỗi xảy ra trong quá trình thêm dữ liệu, vui lòng thử lại!\nChi tiết: " + ex.StackTrace,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            queryString = "select* from Item order by id desc limit 1";
            repository.cmd.CommandText = queryString;
            using (DbDataReader reader = repository.cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    MessageBox.Show(
                        "Data chưa có dữ liệu",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    while (reader.Read())
                    {
                        Models.Item temp = new Models.Item(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetInt64(3),
                            reader.GetInt64(4),
                            reader.GetString(5),
                            reader.GetBoolean(6));
                        this.listSanPham.Add(temp);
                    }
                }
            }
        }

        /// <summary>
        /// Edit SanPham
        /// </summary>
        /// <param name="index"></param>
        /// <param name="sp"></param>
        public void UpdateSanPham(Repository.Repository repository, Models.Item sp)
        {
            string queryString = "update Item set name='" + sp.name +
                "',type='" + sp.type +
                "',amount=" + sp.amount +
                ",minimum=" + sp.minimum +
                ",provider='" + sp.provider +
                "',isRequestImport=" + sp.isImportOrder.ToString() +
                " where id=" + sp.ID;
            repository.cmd.CommandText = queryString;
            try
            {
                repository.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Có lỗi xảy ra trong quá trình cập nhật dữ liệu, vui lòng thử lại!\nChi tiết: " + ex.StackTrace,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            this.LoadSanPham(repository);
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

        /// <summary>
        /// Add SanPham's Import Order to DB
        /// </summary>
        /// <param name="repository"></param>
        public void AddSanPhamImportOrder(Repository.Repository repository, Models.ItemOrder data)
        {
            string queryString = "";
            for (int i = 0; i < data.listSP.Count; i++)
            {
                data.listSP[i].isImportOrder = true;
                this.UpdateSanPham(repository, data.listSP[i]);
            }
        //    queryString = "insert into ItemOrder(createddate, owner, type, listItem, isApproved) " +
        //        "values('" + sp.name +
        //        "', '" + sp.type +
        //        "', " + sp.amount +
        //        ", " + sp.minimum +
        //        ", '" + sp.provider +
        //        "', false, false)";
        //    repository.cmd.CommandText = queryString;
        //    try
        //    {
        //        repository.cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(
        //            "Có lỗi xảy ra trong quá trình thêm dữ liệu, vui lòng thử lại!\nChi tiết: " + ex.StackTrace,
        //            "Lỗi",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Error);
        //    }

        //    queryString = "select* from Item order by id desc limit 1";
        //    repository.cmd.CommandText = queryString;
        //    using (DbDataReader reader = repository.cmd.ExecuteReader())
        //    {
        //        if (!reader.HasRows)
        //        {
        //            MessageBox.Show(
        //                "Data chưa có dữ liệu",
        //                "Lỗi",
        //                MessageBoxButtons.OK,
        //                MessageBoxIcon.Error);
        //            return;
        //        }
        //        else
        //        {
        //            while (reader.Read())
        //            {
        //                Models.Item temp = new Models.Item(
        //                    reader.GetInt32(0),
        //                    reader.GetString(1),
        //                    reader.GetString(2),
        //                    reader.GetInt64(3),
        //                    reader.GetInt64(4),
        //                    reader.GetString(5),
        //                    reader.GetBoolean(6));
        //                this.listSanPham.Add(temp);
        //            }

        //        }
        //    }
        }
    }
}
