using QuanLyBanHang.Domains;
using QuanLyBanHang.Models;
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

namespace QuanLyBanHang.Views
{
    public partial class CommentStatistic : Form
    {
        Repository.Repository repository;
        public Models.CommentStatistic commentStatistic;
        public string startDate;
        public string endDate;

        /// <summary>
        /// Default constructor
        /// </summary>
        public CommentStatistic(Repository.Repository repository)
        {
            this.repository = repository;
            DateTime serverTime = DateTime.Now;
            string startTime = serverTime.ToString("yyyy-MM-dd") + " 00:00:00";
            string endTime = serverTime.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00";
            this.startDate = startTime;
            this.endDate = endTime;
            this.InitializeComponent();
            List<Comment> listComments = new QuanLyBinhLuanDomain().LoadBinhLuanInPeriod(repository, startTime, endTime);
            this.commentStatistic = new Models.CommentStatistic(listComments);

            handleData();
        }

        /// <summary>
        /// Handle data from comment Statistic
        /// </summary>
        /// <param name="commentStatistic">Data from comment Statistic</param>
        public void handleData()
        {
            this.pbGood.Value = this.commentStatistic.countGoodComment;
            this.pbGood.Maximum = this.commentStatistic.countTotal;
            this.pbBad.Value = this.commentStatistic.countBadComment;
            this.pbBad.Maximum = this.commentStatistic.countTotal;
            this.pbClassifed.Value = this.commentStatistic.countClassified;
            this.pbClassifed.Maximum = this.commentStatistic.countTotal;
            this.pbNone.Value = this.commentStatistic.countNonClassify;
            this.pbNone.Maximum = this.commentStatistic.countTotal;
            this.pbNormal.Value = this.commentStatistic.countNormalComment;
            this.pbNormal.Maximum = this.commentStatistic.countTotal;

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
                List<Comment> listComments = new QuanLyBinhLuanDomain().LoadBinhLuanInPeriod(this.repository, startTime, this.endDate);
                this.commentStatistic = new Models.CommentStatistic(listComments);
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
                List<Comment> listComments = new QuanLyBinhLuanDomain().LoadBinhLuanInPeriod(this.repository, this.startDate, endTime);
                this.commentStatistic = new Models.CommentStatistic(listComments);
                this.endDate = endTime;

                handleData();
            }
        }
    }
}
