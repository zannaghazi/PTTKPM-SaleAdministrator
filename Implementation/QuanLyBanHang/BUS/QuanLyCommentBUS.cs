using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Windows.Forms;
using DAO;
using DTO;

namespace BUS
{
    public class QuanLyCommentBus
    {
        public List<CommentDTO> listBinhLuan = new List<CommentDTO>();

        /// <summary>
        /// Constructor
        /// </summary>
        public QuanLyCommentBus()
        {
        }

        /// <summary>
        /// Load data of Binhluan from Database
        /// </summary>
        public void LoadBinhLuan(Connection conn, int role)
        {
            this.listBinhLuan = new List<CommentDTO>();
            if (role == DTO.Helper.Constants.USERTYPE_MANAGER)
            {
                this.listBinhLuan = CommentDAO.getAllComment(conn, 1);
            }
            else if (role == DTO.Helper.Constants.USERTYPE_SALE)
            {
                this.listBinhLuan = CommentDAO.getAllComment(conn, 2);
            }
            else
            {
                this.listBinhLuan = CommentDAO.getAllComment(conn, 0);
            }

        }


        /// <summary>
        /// Load data of Binh Luan in Period from Database
        /// </summary>
        /// <param name="conn">Connection</param>
        /// <param name="startTime">Time start</param>
        /// <param name="endTime">Time end</param>
        public void LoadBinhLuanInPeriod(Connection conn, string startTime, string endTime)
        {
            this.listBinhLuan = new List<CommentDTO>();
            this.listBinhLuan = CommentDAO.getCommentByTime(conn, startTime, endTime);
        }

        /// <summary>
        /// Phan loai binh luan
        /// </summary>
        /// <param name="repository">my repository</param>
        /// <param name="cmt">cmt phan loai</param>
        public void UpdateStatus(Connection conn, CommentDTO comment, int status, int role)
        {
            DateTime serverTime = DateTime.Now;
            comment.timeUpdate = serverTime.ToString("yyyy-MM-dd H:mm:ss");
            comment.status = status;

            if (CommentDAO.update(conn, comment))
            {
                this.LoadBinhLuan(conn, role);
            }
            else
            {
                MessageBox.Show(
                    "Có lỗi xảy ra trong quá trình cập nhật dữ liệu, vui lòng thử lại!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Đánh dấu bình luận đã xử lý
        /// </summary>
        /// <param name="repository">my repository</param>
        public void handleMark(Connection conn, CommentDTO comment, int type, int role)
        {
            DateTime serverTime = DateTime.Now;
            comment.timeUpdate = serverTime.ToString("yyyy-MM-dd H:mm:ss");
            comment.handle_type = type;
            if (CommentDAO.update(conn, comment))
            {
                this.LoadBinhLuan(conn, role);
            }
            else
            {
                MessageBox.Show(
                    "Có lỗi xảy ra trong quá trình cập nhật dữ liệu, vui lòng thử lại!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load Binh luan by id
        /// </summary>
        /// <param name="conn">Connection</param>
        /// <param name="id">id binh luan</param>
        /// <returns></returns>
        public CommentDTO loadBinhLuanByID(Connection conn, int id)
        {
            return CommentDAO.singleByID(conn, id);
        }

        /// <summary>
        /// xoa Binh luan by id
        /// </summary>
        /// <param name="conn">Connection</param>
        /// <param name="id">id binh luan</param>
        /// <returns></returns>
        public void XoaBinhLuan(Connection conn, CommentDTO comment)
        {
            if (CommentDAO.delete(conn, comment))
            {
               
            }
            else
            {
                MessageBox.Show(
                    "Có lỗi xảy ra trong quá trình xử lý dữ liệu, vui lòng thử lại!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
