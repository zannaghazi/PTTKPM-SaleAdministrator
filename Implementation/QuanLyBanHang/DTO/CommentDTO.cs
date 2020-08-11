using System;

namespace DTO
{
    public class CommentDTO
    {
        public int ID;
        public int productID;
        public int customerID;
        public int status;
        public string detail;
        public string timeUpdate;
        public int handle_type;
        public bool is_delete;

        /// <summary>
        /// default constructor
        /// </summary>
        public CommentDTO()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="iD">id of comment</param>
        /// <param name="productID">id of product has comment</param>
        /// <param name="customerID">id of customer comment</param>
        /// <param name="status">status of comment</param>
        /// <param name="detail">detail of comment</param>
        public CommentDTO(int iD, int productID, int customerID, int status, string detail, string updateTime, int handle_type)
        {
            ID = iD;
            this.productID = productID;
            this.customerID = customerID;
            this.status = status;
            this.detail = detail;
            this.timeUpdate = updateTime;
            this.handle_type = handle_type;
            this.is_delete = false;
        }
    }
}
