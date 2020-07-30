using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ItemOrderDTO
    {
        public static readonly int IMPORT = 0;
        public static readonly int RETURN = 1;

        public int ID;
        public DateTime date;
        public string owner;
        public int type;
        public List<ItemDTO> listSP;
        public bool isApproved;

        public string listItemID;

        /// <summary>
        /// Constructor create default Item Order
        /// </summary>
        public ItemOrderDTO()
        {
            this.ID = -1;
            this.date = DateTime.Now;
            this.owner = null;
            this.type = IMPORT;
            this.listSP = new List<ItemDTO>();
            this.isApproved = false;
        }

        /// <summary>
        /// Constructor create Item Order with params
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <param name="date">Date that create the order</param>
        /// <param name="owner">Who create the order</param>
        /// <param name="type">Type of order</param>
        /// <param name="listSP">List of SanPham in order</param>
        /// <param name="isApproved">Order is approved by QuanLy or not</param>
        public ItemOrderDTO(DateTime date, string owner, int type, List<ItemDTO> listSP, bool isApproved)
        {
            this.ID = -1;
            this.date = date;
            this.owner = owner;
            this.type = type;
            this.listSP = listSP;
            this.isApproved = isApproved;
        }

        /// <summary>
        /// Constructor create Item Order with item id
        /// </summary>
        /// <param name="date"></param>
        /// <param name="owner"></param>
        /// <param name="type"></param>
        /// <param name="listItemID"></param>
        /// <param name="isApproved"></param>
        public ItemOrderDTO(DateTime date, string owner, int type, string listItemID, bool isApproved)
        {
            this.ID = -1;
            this.date = date;
            this.owner = owner;
            this.type = type;
            this.listItemID = listItemID;
            this.isApproved = isApproved;
        }

        public ItemOrderDTO(int id, DateTime date, string owner, int type, string listItemID, bool isApproved)
        {
            this.ID = id;
            this.date = date;
            this.owner = owner;
            this.type = type;
            this.listItemID = listItemID;
            this.isApproved = isApproved;
        }
    }
}
