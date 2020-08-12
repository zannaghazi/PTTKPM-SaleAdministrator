using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using DAO;

namespace QuanLyBanHang.Views
{
    public partial class CommentStatistic : Form
    {
        //Connection
        public Connection conn;
        public CommentStatisticDTO commentStatistic;
        public string startDate;
        public string endDate;

        public QuanLyCommentBus quanLyCommentBus = new QuanLyCommentBus();



        /// <summary>
        /// Default constructor
        /// </summary>
        public CommentStatistic()
        {
            this.conn = new Connection();
            DateTime serverTime = DateTime.Now;
            string startTime = serverTime.ToString("yyyy-MM-dd") + " 00:00:00";
            string endTime = serverTime.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00";
            this.startDate = startTime;
            this.endDate = endTime;
            quanLyCommentBus.LoadBinhLuanInPeriod(conn, startTime, endTime);
            this.InitializeComponent();
            List<CommentDTO> listComments = quanLyCommentBus.listBinhLuan;
            this.commentStatistic = new CommentStatisticDTO(listComments);

            handleData();
        }

        /// <summary>
        /// Handle data from comment Statistic
        /// </summary>
        /// <param name="commentStatistic">Data from comment Statistic</param>
        public void handleData()
        {
            this.pbGood.Maximum = this.commentStatistic.countTotal;
            this.pbGood.Value = this.commentStatistic.countGoodComment;
            this.pbBad.Maximum = this.commentStatistic.countTotal;
            this.pbBad.Value = this.commentStatistic.countBadComment;
            this.pbClassifed.Maximum = this.commentStatistic.countTotal;
            this.pbClassifed.Value = this.commentStatistic.countClassified;
            this.pbNone.Maximum = this.commentStatistic.countTotal;
            this.pbNone.Value = this.commentStatistic.countNonClassify;
            this.pbNormal.Maximum = this.commentStatistic.countTotal;
            this.pbNormal.Value = this.commentStatistic.countNormalComment;

            this.labelValueGood.Text = this.commentStatistic.countGoodComment + "/" + this.commentStatistic.countTotal;
            this.lableValueBad.Text = this.commentStatistic.countBadComment + "/" + this.commentStatistic.countTotal;
            this.labelValueNormal.Text = this.commentStatistic.countNormalComment + "/" + this.commentStatistic.countTotal;
            this.labelValueClasscified.Text = this.commentStatistic.countClassified + "/" + this.commentStatistic.countTotal;
            this.labelValueNone.Text = this.commentStatistic.countNonClassify + "/" + this.commentStatistic.countTotal;
        }

        /// <summary>
        /// Setting for form
        /// </summary>
        public void InitFormSetting()
        {
            this.pbBad.Maximum = 100;
            this.pbClassifed.Maximum = 100;
            this.pbGood.Maximum = 100;
            this.pbNone.Maximum = 100;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime startDay = this.dateTimePicker1.Value.Date;
            string startTime = startDay.ToString("yyyy-MM-dd") + " 00:00:00";
            if(!this.startDate.Equals(startTime))
            {
                quanLyCommentBus.LoadBinhLuanInPeriod(this.conn, startTime, this.endDate);
                List<CommentDTO> listComments = quanLyCommentBus.listBinhLuan;
                this.commentStatistic = new CommentStatisticDTO(listComments);
                this.startDate = startTime;
                handleData();
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime endDay = this.dateTimePicker2.Value.Date;
            string endTime = endDay.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00";
            if (!this.endDate.Equals(endTime))
            {
                quanLyCommentBus.LoadBinhLuanInPeriod(this.conn, this.startDate, endTime);
                List<CommentDTO> listComments = quanLyCommentBus.listBinhLuan;
                this.commentStatistic = new CommentStatisticDTO(listComments);
                this.endDate = endTime;

                handleData();
            }
        }

    }
}
