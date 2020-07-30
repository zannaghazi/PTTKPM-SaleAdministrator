﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
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
        }

        //    /// <summary>
        //    /// Edit SanPham
        //    /// </summary>
        //    /// <param name="index"></param>
        //    /// <param name="sp"></param>
        //    public void UpdateSanPham(Repository.Repository repository, Models.Item sp)
        //    {
        //        string queryString = "update Item set name='" + sp.name +
        //            "',type='" + sp.type +
        //            "',amount=" + sp.amount +
        //            ",minimum=" + sp.minimum +
        //            ",provider='" + sp.provider +
        //            "',isRequestImport=" + sp.isImportOrder.ToString() +
        //            " where id=" + sp.ID;
        //        repository.cmd.CommandText = queryString;
        //        try
        //        {
        //            repository.cmd.ExecuteNonQuery();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(
        //                "Có lỗi xảy ra trong quá trình cập nhật dữ liệu, vui lòng thử lại!\nChi tiết: " + ex.StackTrace,
        //                "Lỗi",
        //                MessageBoxButtons.OK,
        //                MessageBoxIcon.Error);
        //        }
        //        this.LoadSanPham(repository);
        //    }

        //    /// <summary>
        //    /// Delete SanPham from database
        //    /// </summary>
        //    /// <param name="sp"></param>
        //    public void DeleteSanPham(Repository.Repository repository, Models.Item sp)
        //    {
        //        string queryString = "update Item set isDeleted=true where id=" + sp.ID;
        //        repository.cmd.CommandText = queryString;
        //        try
        //        {
        //            repository.cmd.ExecuteNonQuery();
        //            this.listSanPham.Remove(sp);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(
        //                "Có lỗi xảy ra trong quá trình cập nhật dữ liệu, vui lòng thử lại!\nChi tiết: " + ex.StackTrace,
        //                "Lỗi",
        //                MessageBoxButtons.OK,
        //                MessageBoxIcon.Error);
        //        }
        //    }

        //    /// <summary>
        //    /// Update import order
        //    /// </summary>
        //    /// <param name="repository"></param>
        //    /// <param name="data"></param>
        //    public void UpdateItemOrder(Repository.Repository repository, Models.ItemOrder data, InitPage parent)
        //    {
        //        string queryString = "update ItemOrder set owner='" + data.owner +
        //            "',type=" + data.type +
        //            ",listItem='" + data.listItemID +
        //            "',isApproved=" + data.isApproved.ToString() +
        //            " where id=" + data.ID;
        //        Console.WriteLine(queryString);
        //        repository.cmd.CommandText = queryString;
        //        try
        //        {
        //            repository.cmd.ExecuteNonQuery();
        //            for (int i = 0; i < data.listSP.Count; i++)
        //            {
        //                data.listSP[i].isImportOrder = false;
        //                this.UpdateSanPham(repository, data.listSP[i]);
        //            }
        //            this.LoadSanPhamOrder(repository);
        //            parent.LoadSPOrderCallback();

        //            this.LoadSanPham(repository);
        //            parent.dataSanPham = this.listSanPham;
        //            parent.LoadSanPhamCallback();
        //            parent.selectedBillIndex = -1;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(
        //                "Có lỗi xảy ra trong quá trình cập nhật dữ liệu, vui lòng thử lại!\nChi tiết: " + ex.StackTrace,
        //                "Lỗi",
        //                MessageBoxButtons.OK,
        //                MessageBoxIcon.Error);
        //        }
        //    }

        //    /// <summary>
        //    /// Delete the order
        //    /// </summary>
        //    /// <param name="repository"></param>
        //    /// <param name="data"></param>
        //    public void DeleteItemOrder(Repository.Repository repository, Models.ItemOrder data, InitPage parent)
        //    {
        //        string queryString = "update ItemOrder set isDeleted=true where id=" + data.ID;
        //        Console.WriteLine(queryString);
        //        repository.cmd.CommandText = queryString;
        //        try
        //        {
        //            repository.cmd.ExecuteNonQuery();
        //            for (int i = 0; i < data.listSP.Count; i++)
        //            {
        //                data.listSP[i].isImportOrder = false;
        //                this.UpdateSanPham(repository, data.listSP[i]);
        //            }
        //            this.LoadSanPhamOrder(repository);
        //            parent.LoadSPOrderCallback();

        //            this.LoadSanPham(repository);
        //            parent.dataSanPham = this.listSanPham;
        //            parent.LoadSanPhamCallback();
        //            parent.selectedBillIndex = -1;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(
        //                "Có lỗi xảy ra trong quá trình cập nhật dữ liệu, vui lòng thử lại!\nChi tiết: " + ex.StackTrace,
        //                "Lỗi",
        //                MessageBoxButtons.OK,
        //                MessageBoxIcon.Error);
        //        }
        //    }

        //    /// <summary>
        //    /// Get all Item that Amount lower than Minimum
        //    /// </summary>
        //    /// <returns></returns>
        //    public List<Models.Item> GetLowAmountItem(Repository.Repository repository)
        //    {
        //        List<Models.Item> list = new List<Models.Item>();

        //        string queryString = "select* from Item where isDeleted = false and isRequestImport = false";
        //        repository.cmd.CommandText = queryString;

        //        using (DbDataReader reader = repository.cmd.ExecuteReader())
        //        {
        //            if (!reader.HasRows)
        //            {
        //                MessageBox.Show(
        //                    "Data chưa có dữ liệu",
        //                    "Lỗi",
        //                    MessageBoxButtons.OK,
        //                    MessageBoxIcon.Error);
        //                return new List<Models.Item>();
        //            }
        //            else
        //            {
        //                while (reader.Read())
        //                {
        //                    Models.Item temp = new Models.Item(
        //                        reader.GetInt32(0),
        //                        reader.GetString(1),
        //                        reader.GetString(2),
        //                        reader.GetInt64(3),
        //                        reader.GetInt64(4),
        //                        reader.GetString(5),
        //                        reader.GetBoolean(6));
        //                    if (temp.minimum >= temp.amount)
        //                    {
        //                        list.Add(temp);
        //                    }
        //                }

        //            }
        //        }

        //        return list;
        //    }

        //    /// <summary>
        //    /// Build string id from list SanPham
        //    /// </summary>
        //    /// <param name="data"></param>
        //    /// <returns></returns>
        //    public string BuildListIDString(List<Models.Item> data)
        //    {
        //        string temp = "";
        //        for (int i = 0; i < data.Count; i++)
        //        {
        //            temp += data[i].ID + " ";
        //        }
        //        return temp;
        //    }

        //    /// <summary>
        //    /// Add SanPham's Import Order to DB
        //    /// </summary>
        //    /// <param name="repository"></param>
        //    public void AddSanPhamImportOrder(Repository.Repository repository, Models.ItemOrder data, InitPage parent)
        //    {
        //        string queryString = "";
        //        for (int i = 0; i < data.listSP.Count; i++)
        //        {
        //            data.listSP[i].isImportOrder = true;
        //            this.UpdateSanPham(repository, data.listSP[i]);
        //        }
        //        queryString = "insert into ItemOrder(createddate, owner, type, listItem, isApproved) " +
        //            "values('" + String.Format("{0:yyyy/MM/dd}", DateTime.Now) + "'," +
        //            "'" + data.owner + "'," +
        //            data.type + "," +
        //            "'" + this.BuildListIDString(data.listSP) + "'" +
        //            ", false)";
        //        Console.WriteLine(queryString);
        //        repository.cmd.CommandText = queryString;
        //        try
        //        {
        //            repository.cmd.ExecuteNonQuery();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(
        //                "Có lỗi xảy ra trong quá trình thêm dữ liệu, vui lòng thử lại!\nChi tiết: " + ex.StackTrace,
        //                "Lỗi",
        //                MessageBoxButtons.OK,
        //                MessageBoxIcon.Error);
        //        }

        //        this.LoadSanPhamOrder(repository);
        //        parent.LoadSPOrderCallback();

        //        this.LoadSanPham(repository);
        //        parent.dataSanPham = this.listSanPham;
        //        parent.LoadSanPhamCallback();
        //    }

        //    /*  NHAP HANG */
        //    public List<Models.ItemOrder> LoadApprovedImport(Repository.Repository repository)
        //    {
        //        List<Models.ItemOrder> temp = new List<Models.ItemOrder>();
        //        string queryString = "select* from ItemOrder where isApproved = true and isDeleted = false";
        //        repository.cmd.CommandText = queryString;

        //        using (DbDataReader reader = repository.cmd.ExecuteReader())
        //        {
        //            if (!reader.HasRows)
        //            {
        //                return new List<Models.ItemOrder>();
        //            }
        //            else
        //            {
        //                while (reader.Read())
        //                {
        //                    Models.ItemOrder data = new Models.ItemOrder(
        //                        reader.GetInt32(0),
        //                        reader.GetDateTime(1),
        //                        reader.GetString(2),
        //                        reader.GetInt32(3),
        //                        reader.GetString(4),
        //                        reader.GetBoolean(5));
        //                    temp.Add(data);
        //                }

        //            }
        //        }
        //        for (int i = 0; i < this.listSPOrder.Count; i++)
        //        {
        //            string[] listSPID = temp[i].listItemID.Trim().Split(' ');
        //            List<Models.Item> listOrderItem = new List<Models.Item>();
        //            for (int j = 0; j < listSPID.Length; j++)
        //            {
        //                if (this.GetItemByID(repository, Convert.ToInt32(listSPID[j])).ID != -1)
        //                {
        //                    listOrderItem.Add(this.GetItemByID(repository, Convert.ToInt32(listSPID[j])));
        //                }
        //            }
        //            temp[i].listSP = listOrderItem;
        //        }
        //        return temp;
        //    }
    }
}
